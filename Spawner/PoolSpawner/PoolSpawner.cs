using System;

public class PoolSpawner : ISpawner, IDespawner, IDisposable
{
    public IObjectPoolLibrary _objectPoolLibrary;
    private IPoolCreator _poolCreator;

    public PoolSpawner(IObjectPoolLibrary objectPoolLibrary = null, IPoolCreator poolCreator = null)
    {
        _objectPoolLibrary = objectPoolLibrary == null ? new DictionaryPoolLibrary() : objectPoolLibrary;
        _poolCreator = poolCreator == null ? new DefaultPoolCreator() : poolCreator;
    }

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
        _objectPoolLibrary.AddDependency(prefab, CreatePool(prefab));
    }

    public T Spawn<T>(T prefab)
    {
        IPool<T> pool = _objectPoolLibrary.GetPool(prefab);
        if (pool == null)
        {
            pool = CreatePool(prefab);
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

    private IPool<T> CreatePool<T>(T prefab)
    {
        return _poolCreator.CreatePool(prefab);
    }
}
