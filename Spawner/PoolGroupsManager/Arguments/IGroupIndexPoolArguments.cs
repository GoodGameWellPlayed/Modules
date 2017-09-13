using System;
using UnityEngine;

public interface IGroupIndexPoolArguments : IPoolArguments
{
    PoolGroupPair PoolGroup { get; set; }
}

[Serializable]
public struct PoolGroupPair
{
    [SerializeField] private string _poolGroupName;
    [SerializeField] private int _poolGroupIndex;

    public string PoolGroupName
    {
        get { return _poolGroupName; }
        set { _poolGroupName = value; }
    }

    public int PoolableObjectIndex
    {
        get { return _poolGroupIndex; }
        set { _poolGroupIndex = value; }
    }
}



