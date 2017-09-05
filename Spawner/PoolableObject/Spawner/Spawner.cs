using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is highly recommended to use ExtendableArray as "A" type for your project
/// </summary>
public abstract class Spawner<T, P, A> : MonoBehaviour where T : PoolableObjectArguments 
    where P : PoolableObject where A : IEnumerable<T>
{
    [SerializeField] private SpawnBehavior<T, A> _spawnBehavior;

    private string _pTypeName;
    
    protected A Arguments { get; set; }

    protected abstract void CreateArguments();

    private void Start()
    {
        if (_spawnBehavior == null)
        {
            _spawnBehavior = GetComponent<SpawnBehavior<T, A>>();
        }
        CreateArguments();
        _pTypeName = "";//TODO get class name

        OnStart();
    }

    protected virtual void OnStart()
    {
    }

    void Update ()
    {
        Arguments.GetEnumerator().Dispose();
        _spawnBehavior.GetPoolableArguments(Arguments);

        foreach (T arguments in Arguments)
        {
            OnAfterSpawnObject(Spawn(arguments));
        }

        OnUpdate();
    }

    protected virtual void OnUpdate()
    {
    }

    protected P Spawn(T arguments)
    {
        IPoolGroup<PoolableObject> poolGroup = PoolGroupsManager.Instance.GetPoolGroup
            (arguments.PoolableObjectGroupNameIndex.PoolGroupName);

        PoolableObject poolableObject = poolGroup.Pools
            [arguments.PoolableObjectGroupNameIndex.PoolableObjectIndex].Spawn();
        if (!(poolableObject is P))
        {
            poolableObject.Despawn();
            Debug.LogError("You should spawn " + _pTypeName + " here! Chose the other object to spawn!");
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
