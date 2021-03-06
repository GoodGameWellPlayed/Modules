﻿namespace Components.Spawner.Pool.PrefabPool
{
    /// <summary>
    /// Конструктор пула по умолчанию
    /// </summary>
    public class DefaultPoolCreator : IPoolCreator
    {
        public IPool<T> CreatePool<T>(T prefab, int objectsCount)
        {
            return new PrefabPool<T>(prefab, true, objectsCount);
        }
    }
}

