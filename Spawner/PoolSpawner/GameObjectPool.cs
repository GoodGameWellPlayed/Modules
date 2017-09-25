using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
    public GameObjectPool(GameObject poolableObject, int poolSize, bool isExtendable = true) : 
        base(poolableObject, poolSize, isExtendable)
    {
    }

    protected override void DestroyPoolableObject(GameObject poolableObject)
    {
        GameObject.Destroy(poolableObject);
    }

    protected override GameObject InstantiateObject()
    {
        GameObject newObject = GameObject.Instantiate(Prefab);
        return newObject;
    }

    protected override void SetObjectActive(GameObject poolableObject, bool isActive)
    {
        poolableObject.gameObject.SetActive(isActive);
    }
}
