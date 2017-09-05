using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnerConditional : TunnelComponentDependent
{
    private ExtendableArray<PoolableObject> _poolableObjectArray;
    private ExtendableArray<PoolableObject> PoolableObjectArray
    {
        get
        {
            if (_poolableObjectArray == null)
            {
                _poolableObjectArray = new ExtendableArray<PoolableObject>(true);
            }
            return _poolableObjectArray;
        }
    }

    protected void AddToDespawnableArray(PoolableObject poolableObjectArray)
    {
        PoolableObjectArray.Add(poolableObjectArray);
    }
    
    void Update ()
    {
        OnBeforeUpdate();

        foreach (PoolableObject obj in PoolableObjectArray)
        {
            obj.Despawn();
        }
        PoolableObjectArray.Dispose();

        OnAfterUpdate();
    }

    protected virtual void OnBeforeUpdate()
    {

    }

    protected virtual void OnAfterUpdate()
    {

    }
}
