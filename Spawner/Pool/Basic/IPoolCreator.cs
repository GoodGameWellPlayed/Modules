namespace Components.Spawner.Pool
{
    /// <summary>
    /// Объект, создающий пул
    /// </summary>
    public interface IPoolCreator
    {
        IPool<T> CreatePool<T>(T prefab);
    }
}

