using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<A, I, P> : ISpawner<P> where A : IPoolArguments
    where P : IPoolableObject, A
{
    protected IArgumentsGenerator<A, I> ArgumentsGenerator { get; set; }
    protected IPoolGetter<P, I> PoolGetter { get; set; }

    public Spawner(IArgumentsGenerator<A, I> argumentsGenerator,
        IPoolGetter<P, I> poolGetter)
    {
        ArgumentsGenerator = argumentsGenerator;
        PoolGetter = poolGetter;
    }

    public IEnumerable<P> Spawn()
    {
        foreach (PoolSpawnInfo<A, I> spawnInfo in ArgumentsGenerator.GetPoolableArguments())
        {
            yield return Spawn(spawnInfo.Arguments, spawnInfo.PoolIdentity);
        }
    }

    protected P Spawn(A arguments, I poolIdentity)
    {
        P poolableObject = PoolGetter.GetPool<IPool<P>>(poolIdentity).Spawn();
        SetArguments(poolableObject, arguments);
        return poolableObject;
    }

    protected void SetArguments(P spawnedObject, A arguments)
    {
        spawnedObject.SetArguments(arguments);
    }
}
