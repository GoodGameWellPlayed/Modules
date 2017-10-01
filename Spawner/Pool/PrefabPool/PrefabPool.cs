using System;
using System.Collections.Generic;

public class PrefabPool<T> : IDisposable, IPool<T>
{
    public T Prefab { get; private set; }
    public int PoolSize { get; private set; }
    public bool IsExtendable { get; set; }

    private Queue<T> _ready;
    private List<T> _pooled;

    public IObjectInstantiator<T> ObjectInstantiator { private get; set; }

    public PrefabPool(T prefab, bool isExtendable = true, int poolSize = 10)
    {
        _ready = new Queue<T>();
        _pooled = new List<T>();

        Prefab = prefab;
        IsExtendable = isExtendable;
        PoolSize = poolSize;

        ObjectInstantiator = ObjectInstantiatorFactory.GetObjectInstantiator(prefab);

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
        if (_ready.Count==0)
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

        T spawnableObjectDequeue = _ready.Dequeue();
        SetObjectActive(spawnableObjectDequeue, true);
        _pooled.Add(spawnableObjectDequeue);
        return spawnableObjectDequeue;
    }

    public void ReturnToPool(T poolableObject)
    {
        _ready.Enqueue(poolableObject);
        _pooled.Remove(poolableObject);

        SetObjectActive(poolableObject, false);
    }

    private void InstantiateObject(bool isActive)
    {
        T spawnableObjectEnqueue = ObjectInstantiator.InstantiateObject(Prefab); 
        _ready.Enqueue(spawnableObjectEnqueue);
        SetObjectActive(spawnableObjectEnqueue, false);
    }

    public void Dispose()
    {
        while (_ready.Count > 0)
        {
            DestroySpawnableObject(_ready.Dequeue());
        }
        for (int i = 0; i < _pooled.Count; i++)
        {
            DestroySpawnableObject(_pooled[i]);
        }
        _ready.Clear();
        _pooled.Clear();
    }

    private void SetObjectActive(T poolableObject, bool isActive)
    {
        ObjectInstantiator.SetObjectActive(poolableObject, isActive);
    }

    private void DestroySpawnableObject(T spawnableObject)
    {
        ObjectInstantiator.DestroySpawnableObject(spawnableObject);
    }
}

