using UnityEngine;

[System.Serializable]
public abstract class PoolableObjectArguments
{
    public PoolGroupNameObjectIdPair PoolableObjectGroupNameIndex;
}

[System.Serializable]
public struct PoolGroupNameObjectIdPair
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

