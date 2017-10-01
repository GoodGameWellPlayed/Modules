public struct TileId
{
    public byte Value { get; private set; }

    public TileId(TileType tileType, byte index)
    {
        Value = index;
    }
}
