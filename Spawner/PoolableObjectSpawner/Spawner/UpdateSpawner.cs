using UnityEngine;

public abstract class UpdateSpawner<A, I, P> : MonoBehaviour where A : IPoolArguments
    where P : PoolableObject
{
    protected abstract IArgumentsGenerator<A, I> ArgumentsGenerator { get; }

    void Update ()
    {
        foreach (PoolSpawnInfo<A, I> spawnInfo in ArgumentsGenerator.GetPoolableArguments())
        {
            OnAfterSpawnObject(Spawn(spawnInfo.Arguments, spawnInfo.PoolIdentity));
        }

        OnUpdate();
    }

    protected virtual void OnUpdate() { }

    protected abstract P SpawnPoolableObject(I objectIdentity);

    protected P Spawn(A arguments, I poolIdentity)
    {
        P poolableObject = SpawnPoolableObject(poolIdentity);
        SetArguments(poolableObject, arguments);
        return poolableObject;
    }

    protected virtual void OnAfterSpawnObject(P spawnedObject)
    {
    }
    
    protected abstract void SetArguments(P spawnedObject, A arguments);
}
