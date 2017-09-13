using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPoolGetterSpawner<A, P> : Spawner<A, P, P> where A : IPoolArguments
    where P : IPoolableObject, A
{
    public PrefabPoolGetterSpawner(IArgumentsGenerator<A, P> argumentsGenerator, IPrefabPoolGetter<P, IPool<P>> poolGetter) : 
        base(argumentsGenerator, poolGetter)
    {
    }
}
