using UnityEngine;

[System.Serializable]
public struct TunnelVector2
{
    [SerializeField] private Angle _angleDegrees;
    [SerializeField] private float _height;

    public Angle AngleDegrees { get { return _angleDegrees; } set { _angleDegrees = value; } }
    public float Height { get { return _height; } set { _height = value; } }

    private Vector2 PositionVector
    {
        get
        {
            return new Vector2(AngleDegrees.Value, Height);
        }
        set
        {
            _angleDegrees = new Angle(value.x);
            _height = value.y;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return AngleDegrees.Value == 0 && Height == 0;
        }
    }

    public void Normalize()
    {
        PositionVector = PositionVector.normalized;
    }

    public override bool Equals(object obj)
    {
        if (obj is TunnelVector3)
        {
            TunnelVector3 compare = (TunnelVector3)obj;
            return compare.AngleDegrees == AngleDegrees &&
                   compare.Height == Height;
        }
        else if (obj is TunnelVector2)
        {
            TunnelVector2 compare = (TunnelVector2)obj;
            return compare.AngleDegrees == AngleDegrees &&
                   compare.Height == Height;
        }
        return base.Equals(obj);
    }

    public static bool operator ==(TunnelVector2 vector1, TunnelVector2 vector2)
    {
        return vector1.Equals(vector2);
    }

    public static bool operator !=(TunnelVector2 vector1, TunnelVector2 vector2)
    {
        return !(vector1 == vector2);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

