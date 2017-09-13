using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolableObject
{
    public IPool<PoolableObject> Pool { get; private set; }

    public PoolableObject InstantiateObject(IPool<PoolableObject> pool)
    {
        GameObject instance = Instantiate(gameObject);
        PoolableObject instancePoolableObject = instance.GetComponent<PoolableObject>();

        if (instancePoolableObject == null)
        {
            instancePoolableObject = instance.AddComponent<PoolableObject>();
        }

        Pool = pool;

        return instancePoolableObject;
    }

    public void Despawn()
    {
        Pool.Despawn(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void OnAfterSpawn()
    {
    }

    public virtual void OnBeforeDespawn()
    {
    }

    public virtual void OnSpawnerUpdate()
    {
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}

