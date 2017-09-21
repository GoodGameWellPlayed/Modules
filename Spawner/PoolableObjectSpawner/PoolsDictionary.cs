using System.Collections.Generic;

public abstract class PoolsDictionary<P, I> where P : IPoolableObject
    where I : IPool<P>
{
    private Dictionary<P, I> _poolsDictionary;

    public PoolsDictionary()
    {
        _poolsDictionary = new Dictionary<P, I>(10);
    }

    public I GetPool(P poolableObjectPrefab)
    {
        if (_poolsDictionary.ContainsKey(poolableObjectPrefab))
        {
            return _poolsDictionary[poolableObjectPrefab];
        }
        I pool = CreatePool(poolableObjectPrefab);
        _poolsDictionary.Add(poolableObjectPrefab, pool);
        return pool;
    }

    protected abstract I CreatePool(P poolableObjectPrefab);
}
