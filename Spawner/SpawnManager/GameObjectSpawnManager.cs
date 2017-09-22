using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawnManager : SpawnManager<MonoBehaviour>
{
    private static GameObjectSpawnManager _instance;
    public static GameObjectSpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObjectSpawnManager();
            }
            return _instance;
        }
    }

    protected override ISpawner<T> CreateSpawner<T>(T prefab)
    {
        return new GameObjectPrefabPoolSpawner<T>(prefab);
    }
}
