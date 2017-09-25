using System.Collections.Generic;

public abstract class SpawnManager<B>
{
    private Dictionary<ISpawnableObject, object> _dictionary;

    protected SpawnManager()
    {
        _dictionary = new Dictionary<ISpawnableObject, object>();
    }

    public virtual T SpawnObject<T>(T prefab) where T : B, ISpawnableObject
    {
        ISpawner<T> spawner = GetSpawner(prefab);
        T spawnedObject = spawner.Spawn();
        SetSpawner(spawnedObject, spawner);
        return spawnedObject;
    }

    public virtual void DespawnObject<T>(T spawnedObject) where T : B, ISpawnableObject
    {
        spawnedObject.Despawner.Despawn(spawnedObject);
    }

    private ISpawner<T> GetSpawner<T>(T prefab) where T : B, ISpawnableObject
    {
        SetSpawner(prefab, CreateSpawner<T>(prefab));
        return _dictionary[prefab] as ISpawner<T>;
    }

    private void SetSpawner<T>(T prefab, ISpawner<T> spawner) where T : B, ISpawnableObject
    {
        if (!_dictionary.ContainsKey(prefab))
        {
            _dictionary.Add(prefab, spawner);
        }
    }

    protected abstract ISpawner<T> CreateSpawner<T>(T prefab) where T : B, ISpawnableObject;
}

