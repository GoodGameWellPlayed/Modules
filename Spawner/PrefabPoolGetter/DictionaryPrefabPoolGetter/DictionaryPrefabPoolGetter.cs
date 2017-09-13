using System;
using System.Collections.Generic;

public class DictionaryPrefabPoolGetter<P, I> : IPrefabPoolGetter<P> where P : IPoolableObject
    where I : IPool<P>
{
    private Dictionary<P, I> _poolsDictionary;
    private Func<P, I> _createPoolFunction;

    public DictionaryPrefabPoolGetter(Func<P, I> createPoolFunction)
    {
        _poolsDictionary = new Dictionary<P, I>(10);
        _createPoolFunction = createPoolFunction;
    }

    public I1 GetPool<I1>(P poolableObjectPrefab) where I1 : IPool<P>
    {
        CreatePoolIfAbsent(poolableObjectPrefab);
        return _poolsDictionary[poolableObjectPrefab] as I1;
    }

    public void CreatePoolIfAbsent(P poolableObjectPrefab)
    {
        if (!_poolsDictionary.ContainsKey(poolableObjectPrefab))
        {
            I pool = InstantiatePool(poolableObjectPrefab);
            _poolsDictionary.Add(poolableObjectPrefab, pool);
        }
    }

    protected I InstantiatePool(P poolableObjectPrefab)
    {
        return _createPoolFunction(poolableObjectPrefab);
    }
}
