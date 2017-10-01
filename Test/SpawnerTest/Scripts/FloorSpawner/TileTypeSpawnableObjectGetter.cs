using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileTypeSpawnableObjectGetter : ISpawnableObjectGetter<TileType, Tile>
{
    [SerializeField]
    private TileTypeArrayPair[] _tileTypeArrayPair;

    private Dictionary<TileType, ArraySpawnableObjectGetter> _tileDictionary;

    private Dictionary<TileType, ArraySpawnableObjectGetter> TileDictionary
    {
        get
        {
            if (_tileDictionary == null)
            {
                _tileDictionary = new Dictionary<TileType, ArraySpawnableObjectGetter>();
                for (int i = 0; i < _tileTypeArrayPair.Length; i++)
                {
                    _tileDictionary.Add(_tileTypeArrayPair[i].TileType, 
                        _tileTypeArrayPair[i].SpawnableObjectGetter);
                }
            }
            return _tileDictionary;
        }
    }

    public Tile GetSpawnableObject(TileType objectIdentity)
    {
        if (objectIdentity == TileType.Emptyness)
        {
            return null;
        }
        return TileDictionary[objectIdentity].GetRandomSpawnableObject() as Tile;
    }

    private TileType[] _emptyTileTypes = { TileType.Emptyness };

    private TileType[] _randomAccessedTileTypes;
    private TileType[] RandomAccessedTileTypes
    {
        get
        {
            if (_randomAccessedTileTypes == null)
            {
                int tileTypesLength = Tile.CountOfTileTypes;
                List<TileType> typesList = new List<TileType>();
                Array values = Enum.GetValues(typeof(TileType));
                for (int i = 0; i < values.Length; i++)
                {
                    bool isAccessible = true;
                    TileType tileType = (TileType)(values.GetValue(i));
                    for (int j = 0; j < _emptyTileTypes.Length; j++)
                    {
                        if (_emptyTileTypes[j] == tileType)
                        {
                            isAccessible = false;
                            break;
                        }
                    }
                    if (isAccessible)
                    {
                        typesList.Add(tileType);
                    }
                }
                _randomAccessedTileTypes = typesList.ToArray();
            }
            return _randomAccessedTileTypes;
        }
    }

    public virtual Tile GetRandomSpawnableObject()
    {
        return GetSpawnableObject(RandomAccessedTileTypes[UnityEngine.Random.Range(0,
            RandomAccessedTileTypes.Length)]);
    }
}

[Serializable]
public class TileTypeArrayPair
{
    [SerializeField] public TileType TileType;
    [SerializeField] public ArraySpawnableObjectGetter SpawnableObjectGetter;
}

