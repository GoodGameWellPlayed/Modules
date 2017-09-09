using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is highly recommended to use ExtendableArray as "A" type for your project
/// </summary>
public abstract class Spawner<T, P> : MonoBehaviour where T : PoolableObjectArguments 
    where P : PoolableObject
{
    protected abstract IArgumentsGenerator ArgumentsGenerator { get; }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart()
    {
    }

    void Update ()
    {
        foreach (PoolableObjectArguments arguments in ArgumentsGenerator.GetPoolableArguments())
        {
            if (!(arguments is T))
            {
                Debug.LogError("Arguments should be of the type " + typeof(T));
            }
            else
            {
                OnAfterSpawnObject(Spawn(arguments as T));
            }
        }

        OnUpdate();
    }

    protected virtual void OnUpdate()
    {
    }

    protected abstract IPoolGroup<PoolableObject> GetPoolGroup(string poolGroupName);

    protected P Spawn(T arguments)
    {
        IPoolGroup<PoolableObject> poolGroup = GetPoolGroup
            (arguments.PoolableObjectGroupNameIndex.PoolGroupName);

        IPoolableObject poolableObject = poolGroup.Pools
            [arguments.PoolableObjectGroupNameIndex.PoolableObjectIndex].Spawn();
        if (!(poolableObject is P))
        {
            poolableObject.Despawn();
            Debug.LogError("You should spawn " + typeof(P) + " here! Chose the other object to spawn!");
            return null;
        }

        P pObject = poolableObject as P;

        SetArguments(pObject, arguments);

        return pObject;
    }

    protected virtual void OnAfterSpawnObject(P spawnedObject)
    {
    }
    
    protected abstract void SetArguments(P spawnedObject, T arguments);
}
