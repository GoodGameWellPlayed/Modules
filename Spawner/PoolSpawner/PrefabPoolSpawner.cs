using System;
using System.Collections.Generic;

public abstract class PrefabPoolSpawner<T> : ISpawner<T>, IDespawner where T : ISpawnableObject
{
    public T Prefab { get; private set; }
    public int PoolSize { get; set; }
    public bool IsExtendable { get; set; }

    public bool IsInited { get; private set; }

    protected Queue<T> _ready;
    protected List<T> _pooled;

    public PrefabPoolSpawner(T spawnableObject, bool isExtendable = true)
    {
        _ready = new Queue<T>();
        _pooled = new List<T>();

        Prefab = spawnableObject;
        IsExtendable = isExtendable;

        Init();
    }

    public void Init()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            InstantiateObject(false);
        }

        IsInited = true;
    }

    public virtual T Spawn()
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
        spawnableObjectDequeue.OnAfterSpawn();
        _pooled.Add(spawnableObjectDequeue);
        return spawnableObjectDequeue;
    }

    public virtual void Despawn(ISpawnableObject spawnableObject)
    {
        _ready.Enqueue((T)spawnableObject);
        _pooled.Remove((T)spawnableObject);

        spawnableObject.OnBeforeDespawn();
        SetObjectActive((T)spawnableObject, false);
    }

    private void InstantiateObject(bool isActive)
    {
        T spawnableObjectEnqueue = InstantiateObject();
        _ready.Enqueue(spawnableObjectEnqueue);
        SetObjectActive(spawnableObjectEnqueue, false);
        spawnableObjectEnqueue.Despawner = this;
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
        IsInited = false;
    }

    protected abstract T InstantiateObject();

    protected abstract void SetObjectActive(T spawnableObject, bool isActive);

    protected abstract void DestroySpawnableObject(T spawnableObject);

}

