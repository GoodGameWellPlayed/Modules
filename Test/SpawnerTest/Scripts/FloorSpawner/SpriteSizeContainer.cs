using UnityEngine;

public struct SpriteSizeContainer
{
    public Vector2 TileSizePixels { get; private set; }
    public Vector2 TileSizeUnits { get; private set; }

    public SpriteSizeContainer(Sprite sprite)
    {
        Vector2 spriteSize = sprite.rect.size;
        float tilePixelsPerUnits = sprite.pixelsPerUnit;
        float x = spriteSize.x;
        float y = spriteSize.y;
        TileSizePixels = new Vector2(x, y);
        TileSizeUnits = TileSizePixels / tilePixelsPerUnits;
    }
}
