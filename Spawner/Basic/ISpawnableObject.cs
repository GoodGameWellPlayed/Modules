using System;
namespace Components.Spawner
{
    /// <summary>
    /// Интерфейс для объектов, которые можно спавнить
    /// </summary>
    public interface ISpawnableObject
    {
        void OnAfterSpawn();
        void OnBeforeDespawn();
    }
}

