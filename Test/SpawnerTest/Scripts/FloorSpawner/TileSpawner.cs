using System;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour, IEventListener<CameraMoveEventArguments>
{
    [SerializeField] private TileMap _tileMap;

    private Dictionary<IntVector2, Tile> _spawnedTiles;
    private Dictionary<IntVector2, Tile> SpawnedTiles
    {
        get
        {
            if (_spawnedTiles == null)
            {
                _spawnedTiles = new Dictionary<IntVector2, Tile>();
            }
            return _spawnedTiles;
        }
    }

    private IntRect _screenRectangle = IntRect.Zero;
    public Rect ScreenRectangleInUnits
    {
        set
        {
            IntRect newScreenRect = _tileMap.Grid.Grid.GetRectangle(value);
            if (_screenRectangle.Equals(newScreenRect))
            {
                return;
            }

            DespawnOld(newScreenRect);
            SpawnNew(newScreenRect);

            _screenRectangle = newScreenRect;
        }
    }

    private void SpawnNew(IntRect newRect)
    {
        if (newRect.IsEmpty)
        {
            return;
        }
        foreach (IntVector2 vector2 in newRect.GetPoints())
        {
            if (!_screenRectangle.IsPointInRect(vector2))
            {
                Spawn(vector2);
            }
        }
    }

    private void DespawnOld(IntRect newRect)
    {
        if (_screenRectangle.IsEmpty)
        {
            return;
        }

        foreach (IntVector2 vector2 in _screenRectangle.GetPoints())
        {
            if (!newRect.IsPointInRect(vector2))
            {
                Despawn(vector2);
            }
        }
    }

    private void Spawn(IntVector2 position)
    {
        Tile prefab = _tileMap.GetSpawnableObject(position);

        if (prefab != null)
        {
            Tile spawned =
                GameObjectSpawnManager.Instance.SpawnObject(prefab);

            if (spawned != null)
            {
                spawned.transform.position = _tileMap.GetTilePosition(position);
                spawned.transform.parent = transform;
                SpawnedTiles.Add(position, spawned);
            }
        }
    }

    private void Despawn(IntVector2 position)
    {
        if (SpawnedTiles.ContainsKey(position))
        {
            GameObjectSpawnManager.Instance.DespawnObject(SpawnedTiles[position]);
            SpawnedTiles.Remove(position);
        }
    }

    private void Start()
    {
        TypeEventManager.Instance.SubscribeListener(this);
    }

    public void HandleEvent(CameraMoveEventArguments arguments, object sender)
    {
        Vector3 topLeft = arguments.CameraScreenRect.min;
        Vector3 size = arguments.CameraScreenRect.size;

        ScreenRectangleInUnits = new Rect(topLeft.x, -topLeft.y, size.x, size.y);
    }
}
