using UnityEngine;

public abstract class ArraySpawnableObjectGetter<T> : MonoBehaviour, ISpawnableObjectGetter<int, T>
    where T : MonoBehaviour, ISpawnableObject
{
    [SerializeField] private string _name;
    [SerializeField] private T[] _spawnableObjects;

    public T GetRandomSpawnableObject()
    {
        return _spawnableObjects[Random.Range(0, _spawnableObjects.Length)];
    }

    public T GetSpawnableObject(int objectIdentity)
    {
        return _spawnableObjects[objectIdentity];
    }
}

public class ArraySpawnableObjectGetter : ISpawnableObjectGetter<int>
{
    [SerializeField] private string _name;
    [SerializeField] private SpawnableObjectWrapper[] _spawnableObjects;

    public ISpawnableObject GetRandomSpawnableObject()
    {
        return _spawnableObjects[Random.Range(0, _spawnableObjects.Length)].SpawnableObject;
    }

    public ISpawnableObject GetSpawnableObject(int objectIdentity)
    {
        return _spawnableObjects[objectIdentity].SpawnableObject;
    }
}

