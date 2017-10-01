using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid<T>
{
    public SquareGrid Grid { get; private set; }

    private T[,] _array;
    private T _defaultT;

    public SquareGrid(int width, int height, float cellWidth, float cellHeight, T defaultT = default(T))
    {
        Grid = new SquareGrid(width, height, cellWidth, cellHeight);
        _array = new T[width, height];
        _defaultT = defaultT;
    }

    private bool IsPointInGrid(int x, int y)
    {
        return (x >= 0 && x < _array.GetLength(0)) && 
            (y >= 0 && y < _array.GetLength(1));
    }

    public T this[int x, int y]
    {
        get
        {
            if (!IsPointInGrid(x, y))
            {
                return _defaultT;
            }
            return _array[x, y];
        }
        set
        {
            if (IsPointInGrid(x, y))
            {
                _array[x, y] = value;
            }
        }
    }

    public T this[float x, float y]
    {
        get
        {
            int xInt = (int)(x / Grid.CellWidth);
            int yInt = (int)(y / Grid.CellHeight);
            return _array[xInt, yInt];
        }
    }

    public T this[Vector2 vector]
    {
        get
        {
            return this[vector.x, vector.y];
        }
    }

    public T this[IntVector2 param1]
    {
        get
        {
            return this[param1.X, param1.Y];
        }
    }
}

public struct SquareGrid
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float CellWidth { get; private set; }
    public float CellHeight { get; private set; }
    public float WidthPixels { get { return Width * CellWidth; } }
    public float HeightPixels { get { return Height * CellHeight; } }

    public SquareGrid(int width, int height, float cellWidth, float cellHeight)
    {
        Width = width;
        Height = height;
        CellWidth = cellWidth;
        CellHeight = cellHeight;
    }

    public IntVector2 GetCellPosition(Vector2 position)
    {
        return new IntVector2(position.x / CellWidth, position.y / CellHeight);
    }

    public IntRect GetRectangle(Rect rectangle)
    {
        IntVector2 topLeftInt = GetCellPosition(rectangle.min);
        IntVector2 bottomRightInt = new IntVector2(
            Mathf.Ceil(rectangle.max.x / CellWidth),
            Mathf.Ceil(rectangle.max.y / CellWidth));
        IntVector2 size = bottomRightInt - topLeftInt;

        return new IntRect(topLeftInt, size);
    }
}

public struct IntVector2
{
    public static IntVector2 Zero = new IntVector2(0, 0);

    public int X { get; private set; }
    public int Y { get; private set; }

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public IntVector2(float x, float y)
    {
        X = (int)x;
        Y = (int)y;
    }

    public IntVector2(Vector2 vector2)
    {
        X = (int)vector2.x;
        Y = (int)vector2.y;
    }

    public override bool Equals(object obj)
    {
        IntVector2 other = (IntVector2)obj;
        return (other.X == X && other.Y == Y);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static IntVector2 operator +(IntVector2 vector1, IntVector2 vector2)
    {
        return new IntVector2(vector1.X + vector2.X, vector1.Y + vector2.Y);
    }

    public static IntVector2 operator -(IntVector2 vector1, IntVector2 vector2)
    {
        return new IntVector2(vector1.X - vector2.X, vector1.Y - vector2.Y);
    }
}

public struct IntRect
{
    public static IntRect Zero = new IntRect(IntVector2.Zero, IntVector2.Zero);

    public IntVector2 TopLeft { get; private set; }
    public IntVector2 Size { get; private set; }
    public IntVector2 BottomRight
    {
        get
        {
            return new IntVector2(TopLeft.X + Size.X - 1, TopLeft.Y + Size.Y - 1);
        }
    }

    public IntRect(IntVector2 topLeft, IntVector2 size)
    {
        TopLeft = topLeft;
        Size = size;
    }

    public override bool Equals(object obj)
    {
        IntRect other = (IntRect)obj;
        return (other.TopLeft.Equals(TopLeft) && other.Size.Equals(Size));
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public bool IsEmpty
    {
        get
        {
            return Size.X == 0 && Size.Y == 0;
        }
    }

    public bool IsPointInRect(IntVector2 point)
    {
        return IsPointInRect(point.X, point.Y);
    }

    public bool IsPointInRect(int pointX, int pointY)
    {
        return !IsEmpty &&
            pointX >= TopLeft.X && pointX <= BottomRight.X &&
            pointY >= TopLeft.Y && pointY <= BottomRight.Y;
    }

    public IEnumerable<IntVector2> GetPoints()
    {
        if (!IsEmpty)
        {
            for (int x = TopLeft.X; x <= BottomRight.X; x++)
            {
                for (int y = TopLeft.Y; y <= BottomRight.Y; y++)
                {
                    yield return new IntVector2(x, y);
                }
            }
        }
    }

    public void Slice(IntRect slicer)
    {
        if (IsEmpty)
        {
            return;
        }

        if (slicer.IsEmpty)
        {
            TopLeft = IntVector2.Zero;
            Size = IntVector2.Zero;
            return;
        }

        int x1 = TopLeft.X < slicer.TopLeft.X ? slicer.TopLeft.X : TopLeft.X;
        int y1 = TopLeft.Y < slicer.TopLeft.Y ? slicer.TopLeft.Y : TopLeft.Y;
        int x2 = BottomRight.X > slicer.BottomRight.X ? slicer.BottomRight.X : BottomRight.X;
        int y2 = BottomRight.Y > slicer.BottomRight.Y ? slicer.BottomRight.Y : BottomRight.Y;

        TopLeft = new IntVector2(x1, y1);
        Size = new IntVector2(x2 - x1 + 1, y2 - y1 + 1);
    }
}

