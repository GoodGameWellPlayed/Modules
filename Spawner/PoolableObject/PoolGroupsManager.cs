﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGroupsManager : Singleton<PoolGroupsManager>, IDisposable
{
    [SerializeField] private string _poolGroupName;
    [SerializeField] private PoolableObject[] _poolableObjectArray;

    private void Start()
    {
        _groupsDictionary = new PoolGroupDictionary();

        PoolableObjectsGroup newGroup = new PoolableObjectsGroup(_poolGroupName);
        for (int i = 0; i < _poolableObjectArray.Length; i++)
        {
            newGroup.Pools.Add(new PrefabPool(_poolableObjectArray[i]));
        }

        _groupsDictionary.Add(_poolGroupName, newGroup);
    }

    private PoolGroupDictionary _groupsDictionary;

    private PoolGroupDictionary GroupsDictionary
    {
        get
        {
            if (_groupsDictionary == null)
            {
                _groupsDictionary = new PoolGroupDictionary();
            }
            return _groupsDictionary;
        }
    }
    
    public IPoolGroup<PoolableObject>[] GetPoolGroupArray()
    {
        IPoolGroup<PoolableObject>[] result = new IPoolGroup<PoolableObject>[GroupsDictionary.Count];

        GroupsDictionary.Values.CopyTo(result, 0);
        return result;
    }

    public IPoolGroup<PoolableObject> GetPoolGroup(string poolGroupName)
    {
        return GroupsDictionary[poolGroupName];
    }

    public void AddPoolGroup(IPoolGroup<PoolableObject> poolGroup)
    {
        GroupsDictionary.Add(poolGroup.Name, poolGroup);
    }

    public void RemovePoolGroup(string poolGroupName)
    {
        GroupsDictionary.Destroy(poolGroupName);
    }

    public void Dispose()
    {
        if (_groupsDictionary != null)
        {
            _groupsDictionary.DestroyAll();
        }
    }
}
