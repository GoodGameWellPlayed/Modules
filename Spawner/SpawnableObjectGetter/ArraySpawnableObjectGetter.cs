using UnityEngine;

public abstract class ArraySpawnableObjectGetter : MonoBehaviour, ISpawnableObjectGetter<int>
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
