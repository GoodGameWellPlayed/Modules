using System.Collections.Generic;

public abstract class PrefabPool<P> : IPool<P> where P : class, IPoolableObject
{
    public string Name { get; set; }
    public P Prefab { get; set; }
    public int PoolSize { get; set; }
    public bool IsExtendable { get; set; }

    public bool IsInited { get; private set; }
    public P[] Pooled { get { return _pooled.ToArray(); } }
    public P[] Ready { get { return _ready.ToArray(); } }

    protected Queue<P> _ready;
    protected List<P> _pooled;

    public PrefabPool(P poolableObject, bool isExtendable = true)
    {
        _ready = new Queue<P>();
        _pooled = new List<P>();

        Prefab = poolableObject;
        IsExtendable = isExtendable;

        Init();
    }

    public void Init()
    {
        P poolableObject;
        for (int i = 0; i < PoolSize; i++)
        {
            poolableObject = InstantiateObject();
            _ready.Enqueue(poolableObject);
            poolableObject.SetActive(false);
        }

        IsInited = true;
    }

    protected abstract P InstantiateObject();

    public virtual P Spawn()
    {
        if (_ready.Count==0)
        {
            if (IsExtendable)
            {
                P poolableObjectEnqueue = InstantiateObject();
                _ready.Enqueue(poolableObjectEnqueue);
            }
            else
            {
                return null;
            }
        }

        P poolableObjectDequeue = _ready.Dequeue();
        poolableObjectDequeue.SetActive(true);
        poolableObjectDequeue.OnAfterSpawn();
        _pooled.Add(poolableObjectDequeue);
        return poolableObjectDequeue;
    }

    public virtual void Despawn(P poolableObject)
    {
        _ready.Enqueue(poolableObject);
        _pooled.Remove(poolableObject);

        poolableObject.OnBeforeDespawn();
        poolableObject.SetActive(false);
    }

    public void Destroy()
    {
        while (_ready.Count > 0)
        {
            _ready.Dequeue().Destroy();
        }
        for (int i = 0; i < _pooled.Count; i++)
        {
            _pooled[i].Destroy();
        }
        _ready.Clear();
        _pooled.Clear();
        IsInited = false;
    }
}

