using UnityEngine;

public class ArrayPoolableObjectGetter : MonoBehaviour, IPoolableObjectGetter<int>
{
    [SerializeField] private string _name;
    [SerializeField] private PoolableObject[] _poolableObjects;

    public string Name { get { return _name; } }

    public PoolableObject GetPoolableObject(int objectIdentity)
    {
        return _poolableObjects[objectIdentity];
    }

    public virtual PoolableObject GetRandomPoolableObject()
    {
        return _poolableObjects[Random.Range(0, _poolableObjects.Length)];
    }
}
