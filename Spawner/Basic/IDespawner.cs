namespace Components.Spawner
{
    /// <summary>
    /// Интерфейс для деспавнера объектов
    /// </summary>
    public interface IDespawner
    {
        void Despawn<T>(T spawnableObject);
    }
}

