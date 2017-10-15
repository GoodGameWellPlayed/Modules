using UnityEngine;

[System.Serializable]
public struct TunnelVector3
{
    public static TunnelVector3 Zero = new TunnelVector3(0, new Angle(), 0);

    [SerializeField] private float _depth;
    [SerializeField] private Angle _angleDegrees;
    [SerializeField] private float _height;

    public float Depth { get { return _depth; } set { _depth = value; } }
    public Angle AngleDegrees { get { return _angleDegrees; } set { _angleDegrees = value; } }
    /// <summary>
    /// 0 - on the perimeter
    /// </summary>
    public float Height { get { return _height; } set { _height = value; } }

    private Vector3 PositionVector
    {
        get
        {
            return new Vector3(Depth, AngleDegrees.Value, Height);
        }
        set
        {
            _depth = value.x;
            _angleDegrees = new Angle(value.y);
            _height = value.z;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return Depth == 0 && AngleDegrees.Value == 0 && Height == 0;
        }
    }

    public TunnelVector3(float depth, Angle angle, float height)
    {
        _depth = depth;
        _angleDegrees = angle;
        _height = height;
    }

    public TunnelVector3(TunnelVector3 preset)
    {
        _depth = preset._depth;
        _angleDegrees = preset._angleDegrees;
        _height = preset._height;
    }

    public void Rotate(Angle angle)
    {
        _angleDegrees += angle;
    }

    public void Normalize()
    {
        PositionVector = PositionVector.normalized;
    }

    public static TunnelVector3 operator +(TunnelVector3 vector1, TunnelVector3 vector2)
    {
        TunnelVector3 newVector = new TunnelVector3();
        newVector.PositionVector = vector1.PositionVector + vector2.PositionVector;
        return newVector;
    }

    public static TunnelVector3 operator -(TunnelVector3 vector1, TunnelVector3 vector2)
    {
        TunnelVector3 newVector = new TunnelVector3();
        newVector.PositionVector = vector1.PositionVector - vector2.PositionVector;
        return newVector;
    }

    public override bool Equals(object obj)
    {
        if (obj is TunnelVector3)
        {
            TunnelVector3 compare = (TunnelVector3)obj;
            return compare.AngleDegrees == AngleDegrees &&
                   compare.Depth == Depth &&
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

    public static bool operator ==(TunnelVector3 vector3, TunnelVector2 vector2)
    {
        return vector2.Equals(vector3);
    }

    public static bool operator !=(TunnelVector3 vector3, TunnelVector2 vector2)
    {
        return !(vector3 == vector2);
    }

    public static bool operator ==(TunnelVector2 vector2, TunnelVector3 vector3)
    {
        return vector3.Equals(vector2);
    }

    public static bool operator !=(TunnelVector2 vector2, TunnelVector3 vector3)
    {
        return !(vector2 == vector3);
    }

    public static bool operator ==(TunnelVector3 vector1, TunnelVector3 vector2)
    {
        return vector1.Equals(vector2);
    }

    public static bool operator !=(TunnelVector3 vector1, TunnelVector3 vector2)
    {
        return !(vector1 == vector2);
    }

    public static TunnelVector3 operator *(TunnelVector3 vector, float multiplier)
    {
        vector.PositionVector *= multiplier;
        return vector;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return "Depth : " + Depth + "; Angle : " + AngleDegrees + "; Height " + Height;
    }
}

