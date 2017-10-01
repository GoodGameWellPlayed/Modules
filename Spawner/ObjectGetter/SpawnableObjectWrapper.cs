using System;
using UnityEngine;

[Serializable]
public class SpawnableObjectWrapper
{
    [SerializeField] private GameObject _spawnableObject;

    private ISpawnableObject _resultedObject;

    public ISpawnableObject SpawnableObject
    {
        get
        {
            if (_resultedObject == null)
            {
                _resultedObject = _spawnableObject.GetComponent<ISpawnableObject>();
            }
            return _resultedObject;
        }
    }
}
