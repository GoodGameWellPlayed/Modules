using System;
using System.Collections.Generic;

public abstract class ObjectPool<T> : IDisposable
{
    public T Prefab { get; private set; }
    public int PoolSize { get; private set; }
    public bool IsExtendable { get; set; }

    protected Queue<T> _ready;
    protected List<T> _pooled;

    public ObjectPool(T poolableObject, int poolSize, bool isExtendable = true)
    {
        _ready = new Queue<T>();
        _pooled = new List<T>();

        Prefab = poolableObject;
        PoolSize = poolSize;
        IsExtendable = isExtendable;

        Init();
    }

    private void Init()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            InstantiateObject(false);
        }
    }

    public T GetFromPool()
    {
        if (_ready.Count == 0)
        {
            if (IsExtendable)
            {
                InstantiateObject(false);
            }
            else
            {
                return default(T);
            }
        }

        T poolableObjectDequeue = _ready.Dequeue();
        SetObjectActive(poolableObjectDequeue, true);
        _pooled.Add(poolableObjectDequeue);
        return poolableObjectDequeue;
    }

    public void ReturnToPool(T poolableObject)
    {
        _ready.Enqueue(poolableObject);
        _pooled.Remove(poolableObject);

        SetObjectActive(poolableObject, false);
    }

    private void InstantiateObject(bool isActive)
    {
        T poolableObjectEnqueue = InstantiateObject();
        _ready.Enqueue(poolableObjectEnqueue);
        SetObjectActive(poolableObjectEnqueue, false);
    }

    public void Dispose()
    {
        while (_ready.Count > 0)
        {
            DestroyPoolableObject(_ready.Dequeue());
        }
        for (int i = 0; i < _pooled.Count; i++)
        {
            DestroyPoolableObject(_pooled[i]);
        }
        _ready.Clear();
        _pooled.Clear();
    }

    protected abstract T InstantiateObject();

    protected abstract void SetObjectActive(T poolableObject, bool isActive);

    protected abstract void DestroyPoolableObject(T poolableObject);
}
