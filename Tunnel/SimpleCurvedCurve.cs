using UnityEngine;

public class SimpleCurvedCurve : IPositionCurve
{
    private float _radius;
    private float _length;
    private Angle _angle;

    public SimpleCurvedCurve(float radius, float length, Angle angle)
    {
        _radius = radius;
        _length = length;
        _angle = angle;
    }

    public PositionRotation GetPositionRotation(float distance)
    {
        float ang = distance * _angle.Value / _length;
        Vector3 radius = Vector3.back * _radius;
        Quaternion angle = Quaternion.Euler(0, ang, 0);
        return new PositionRotation()
        {
            Position = radius - angle * radius,
            Rotation = angle
        };
    }
}

