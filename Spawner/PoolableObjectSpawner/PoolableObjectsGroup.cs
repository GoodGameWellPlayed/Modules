using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObjectsGroup : IPoolGroup<PoolableObject>
{
    public string Name { get; set; }

    private List<IPool<PoolableObject>> _pools;

    public List<IPool<PoolableObject>> Pools
    {
        get
        {
            if (_pools == null)
            {
                _pools = new List<IPool<PoolableObject>>();
            }
            return _pools;
        }
    }

    public PoolableObjectsGroup(string name)
    {
        Name = name;
    }

    public void Destroy()
    {
        _pools = null;
    }
}
