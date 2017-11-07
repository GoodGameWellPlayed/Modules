namespace Components.Spawner
{
    /// <summary>
    /// Интерфейс спавнера объектов
    /// </summary>
    public interface ISpawner
    {
        T Spawn<T>(T prefab);
    }
}

