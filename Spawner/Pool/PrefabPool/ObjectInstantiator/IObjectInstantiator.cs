namespace Components.Spawner.Pool.PrefabPool
{
    /// <summary>
    /// Интерфейс для класса, создающего копии объекта
    /// для их дальнейшего помещения в пул
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectInstantiator<T>
    {
        T InstantiateObject(T prefab);

        void SetObjectActive(T spawnableObject, bool isActive);

        void DestroySpawnableObject(T spawnableObject);
    }
}

