using UnityEngine;
using System.Collections;
using System;

public abstract class PoolableObject : MonoBehaviour, IPoolableObject
{
    public IPool<PoolableObject> Pool { get; set; }

    public void Despawn()
    {
        Pool.Despawn(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void OnAfterSpawn()
    {
    }

    public virtual void OnBeforeDespawn()
    {
    }

    public virtual void OnSpawnerUpdate()
    {
    }
}
