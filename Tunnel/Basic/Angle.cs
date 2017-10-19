using System;
using UnityEngine;

[Serializable]
public struct Angle
{
    public static float MaxAngle = 360f;
    public static Angle Zero = new Angle(0);
    public static Angle HalfCircle = new Angle(180f);

    [SerializeField] private float _angle;

    public float Value
    {
        get
        {
            if (!IsNormalized)
            {
                Normalize();
            }
            return _angle;
        }
        set
        {
            _angle = value;
        }
    }

    public float ValueRadian
    {
        get
        {
            return Value * Mathf.PI / (MaxAngle / 2f);
        }
        set
        {
            Value = value * (MaxAngle / 2f) / Mathf.PI;
        }
    }

    public Angle(float angle)
    {
        _angle = angle;
    }

    private bool IsNormalized
    {
        get
        {
            return _angle > -MaxAngle && _angle < MaxAngle;
        }
    }

    private void Normalize()
    {
        _angle = _angle % MaxAngle;
    }

    public static Angle operator +(Angle angle1, Angle angle2)
    {
        return new Angle(angle1.Value + angle2.Value);
    }

    public static Angle operator -(Angle angle1, Angle angle2)
    {
        return new Angle(angle1.Value - angle2.Value);
    }

    public static Angle operator *(Angle angle1, Angle angle2)
    {
        return new Angle(angle1.Value * angle2.Value);
    }

    public static Angle operator /(Angle angle1, Angle angle2)
    {
        return new Angle(angle1.Value / angle2.Value);
    }

    public static bool operator ==(Angle angle1, Angle angle2)
    {
        return angle1.Value == angle2.Value;
    }

    public static bool operator !=(Angle angle1, Angle angle2)
    {
        return !(angle1 == angle2);
    }

    public override bool Equals(object obj)
    {
        return this == (Angle)obj;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static Angle operator +(Angle angle, float value)
    {
        return new Angle(angle.Value + value);
    }

    public static Angle operator *(Angle angle, float value)
    {
        return new Angle(angle.Value * value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

