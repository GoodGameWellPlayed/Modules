using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : Spawner<PoolableObjectArguments, BulletPoolableObject>
{
    [SerializeField] IntervalSpawnBehavior _sb;

    protected override IArgumentsGenerator ArgumentsGenerator
    {
        get
        {
            return _sb;
        }
    }

    protected override IPoolGroup<PoolableObject> GetPoolGroup(string poolGroupName)
    {
        return PoolGroupsManager.Instance.GetPoolGroup(poolGroupName);
    }

    protected override void SetArguments(BulletPoolableObject spawnedObject, PoolableObjectArguments arguments)
    {
        spawnedObject.transform.position = transform.position;
    }
}
