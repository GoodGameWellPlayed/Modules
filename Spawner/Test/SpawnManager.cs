using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private PrefabPoolDictionary _dictionary;

    protected override void OnAwake()
    {
        _dictionary = new PrefabPoolDictionary();
    }

    public P SpawnPoolableObject<P>(P prefab) where P : PoolableObject
    {
        return _dictionary.GetPoolGroup(prefab).Spawn() as P;
    }
}
