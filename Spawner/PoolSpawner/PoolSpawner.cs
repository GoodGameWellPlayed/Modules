using Components.Spawner.Pool.PrefabPool;
using System;

namespace Components.Spawner.Pool
{
    /// <summary>
    /// Спавнер объектов с механикой пула
    /// </summary>
    public class PoolSpawner : ISpawner, IDespawner, IDisposable
    {
        private const int DefaultObjectsCount = 10;

        public IObjectPoolLibrary _objectPoolLibrary;
        private IPoolCreator _poolCreator;
        private int _objectsCount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPoolLibrary">Библиотека пулов. Используется для нахождения пула объекта по объекту или его префабу</param>
        /// <param name="poolCreator">Создатель пулов. Переопределяется при необходимости переопределения конструктора пулов</param>
        public PoolSpawner(int objectsCount = DefaultObjectsCount, IObjectPoolLibrary objectPoolLibrary = null, 
            IPoolCreator poolCreator = null)
        {
            _objectPoolLibrary = objectPoolLibrary ?? new DictionaryPoolLibrary();
            _poolCreator = poolCreator ?? new DefaultPoolCreator();
            _objectsCount = objectsCount;
        }

        /// <summary>
        /// Осуществляет деспавн объекта, в случае, если его создавали через данный спавнер
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="spawnableObject">Объект, который нужно деспавнить</param>
        public void Despawn<T>(T spawnableObject)
        {
            IPool<T> pool = _objectPoolLibrary.GetPool(spawnableObject);
            if (pool != null)
            {
                Action<bool> despawnAction = (shouldDespawn) =>
                {
                    if (shouldDespawn)
                    {
                        pool.ReturnToPool(spawnableObject);
                    }
                };

                if (spawnableObject is ISpawnableObject)
                {
                    (spawnableObject as ISpawnableObject).OnBeforeDespawn(despawnAction);
                }
                else
                {
                    despawnAction(true);
                }
            }
            return;
        }

        public void Dispose()
        {
            _objectPoolLibrary.Dispose();
        }

        public void GeneratePool<T>(T prefab)
        {
            _objectPoolLibrary.AddDependency(prefab, CreatePool(prefab, _objectsCount));
        }

        /// <summary>
        /// Осуществляет спавн объекта по префабу
        /// </summary>
        /// <typeparam name="T">Тип префаба (получаемых объектов)</typeparam>
        /// <param name="prefab">Префаб</param>
        /// <returns></returns>
        public T Spawn<T>(T prefab)
        {
            IPool<T> pool = _objectPoolLibrary.GetPool(prefab);
            if (pool == null)
            {
                pool = CreatePool(prefab, _objectsCount);
                _objectPoolLibrary.AddDependency(prefab, pool);
            }

            T spawnedObject = pool.GetFromPool();
            _objectPoolLibrary.AddDependency(spawnedObject, pool);

            if (spawnedObject is ISpawnableObject)
            {
                (spawnedObject as ISpawnableObject).OnAfterSpawn();
            }

            return spawnedObject;
        }

        public IPool<T> CreatePool<T>(T prefab, int objectsCount)
        {
            return _poolCreator.CreatePool(prefab, objectsCount);
        }
    }
}

