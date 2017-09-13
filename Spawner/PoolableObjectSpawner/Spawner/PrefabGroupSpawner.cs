using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrefabGroupSpawner<A, I, P> : Spawner<A, I, P> where A : IPoolArguments
    where P : PoolableObject
{
    protected abstract IPrefabGroup<I, P> PrefabGroup { get; }
    protected abstract PoolsDictionary<P> PoolDictionary { get; }

    protected override P SpawnPoolableObject(I objectIdentity)
    {
        P prefab = PrefabGroup.GetPoolableObject(objectIdentity);
        return PoolDictionary.GetPoolGroup(prefab).Spawn();
    }
}
