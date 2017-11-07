using System;

namespace Components.Spawner.Pool
{
    /// <summary>
    /// Интерфейс пула
    /// </summary>
    /// <typeparam name="T">Тип объекта, содержащегося в пуле</typeparam>
    public interface IPool<T> : IDisposable
    {
        T GetFromPool();
        void ReturnToPool(T poolableObject);
    }
}

