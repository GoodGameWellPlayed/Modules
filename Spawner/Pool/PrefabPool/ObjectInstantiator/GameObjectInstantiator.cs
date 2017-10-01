using UnityEngine;

public class GameObjectInstantiator : IObjectInstantiator<GameObject> {

    public void DestroySpawnableObject(GameObject spawnableObject)
    {
        GameObject.Destroy(spawnableObject);
    }

    public GameObject InstantiateObject(GameObject prefab)
    {
        return GameObject.Instantiate(prefab);
    }

    public void SetObjectActive(GameObject spawnableObject, bool isActive)
    {
        spawnableObject.SetActive(isActive);
    }
}
