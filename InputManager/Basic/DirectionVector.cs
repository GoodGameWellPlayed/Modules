using UnityEngine;

/// <summary>
/// Возвращает вектор длиной в 1
/// </summary>
public struct DirectionVector
{
    private Vector3 _vector;

    public Vector3 Value
    {
        get
        {
            return _vector;
        }
        set
        {
            _vector = value.normalized;
        }
    }

    public static bool operator ==(DirectionVector lhs, DirectionVector rhs)
    {
        return lhs.Value == rhs.Value;
    }

    public static bool operator !=(DirectionVector lhs, DirectionVector rhs)
    {
        return lhs.Value != rhs.Value;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

