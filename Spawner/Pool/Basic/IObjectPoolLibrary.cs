using System;

namespace Components.Spawner.Pool
{
    /// <summary>
    /// Интерфейс библиотеки пулов. Возвращает пул для конкретного объекта
    /// </summary>
    public interface IObjectPoolLibrary : IDisposable
    {
        void AddDependency<T>(T poolableObject, IPool<T> pool);
        void RemoveDependency<T>(T poolableObject);
        IPool<T> GetPool<T>(T poolableObject);
    }
}

