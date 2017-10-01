public interface IObjectInstantiator<T>
{
    T InstantiateObject(T prefab);

    void SetObjectActive(T spawnableObject, bool isActive);

    void DestroySpawnableObject(T spawnableObject);
}

