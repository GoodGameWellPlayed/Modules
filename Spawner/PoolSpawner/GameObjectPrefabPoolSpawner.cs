using System;
using UnityEngine;

public class GameObjectPrefabPoolSpawner<T> : PrefabPoolSpawner<T> where T : MonoBehaviour, ISpawnableObject
{
    public GameObjectPrefabPoolSpawner(T spawnableObject, bool isExtendable = true) : 
        base(spawnableObject, isExtendable)
    {

    }

    protected override void DestroySpawnableObject(T spawnableObject)
    {
        GameObject.Destroy(spawnableObject.gameObject);
    }

    protected override T InstantiateObject()
    {
        return GameObject.Instantiate(Prefab.gameObject).GetComponent<T>();
    }

    protected override void SetObjectActive(T spawnableObject, bool isActive)
    {
        spawnableObject.gameObject.SetActive(isActive);
    }
}
