using System;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour, ISpawnableObjectGetter<IntVector2, Tile>
{
    [SerializeField] private TileTypeSpawnableObjectGetter _spawnableObjectGetter;
    [SerializeField] private string[] _map;

    private Dictionary<TileType, Dictionary<int, TileSurfaceInfo>> _tileSurfaceInfo;

    public Vector3 TopLeftPosition
    {
        get
        {
            return Vector3.zero;
        }
    }

    private SquareGrid<TileType> _grid;

    public SquareGrid<TileType> Grid
    {
        get
        {
            if (_grid == null)
            {
                TileSizeContainer tileInfo = new TileSizeContainer(GetRandomSpawnableObject());

                _grid = new SquareGrid<TileType>(_map[0].Length, _map.Length,
                    tileInfo.TileSizeUnits.x, tileInfo.TileSizeUnits.y, TileType.Emptyness);

                for (int i = 0; i < _grid.Grid.Width; i++)
                {
                    for (int j = 0; j < _grid.Grid.Height; j++)
                    {
                        byte result;
                        byte.TryParse(_map[j][i].ToString(), out result);
                        _grid[i, j] = (TileType)result;
                    }
                }
            }
            return _grid;
        }
    }

    public Tile GetSpawnableObject(IntVector2 objectIdentity)
    {
        TileType tileType = Grid[objectIdentity];
        if (tileType != TileType.Emptyness)
        {
            return _spawnableObjectGetter.GetSpawnableObject(tileType);
        }
        return null;
    }

    public Tile GetRandomSpawnableObject()
    {
        return _spawnableObjectGetter.GetRandomSpawnableObject();
    }

    public Vector3 GetTilePosition(IntVector2 position)
    {
        //todo reverse position
        float x = Grid.Grid.CellWidth * position.X + Grid.Grid.CellWidth / 2f;
        float y = - (Grid.Grid.CellHeight * position.Y + Grid.Grid.CellHeight / 2f);
        return TopLeftPosition + new Vector3(x, y, 0);
    }

    /*public TileSurfaceInfo GetSurfaceInfo(Vector3 position)
    {

    }*/
}

