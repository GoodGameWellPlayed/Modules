using UnityEngine;

public class SimpleCurvedCurve : IPositionCurve
{
    private float _radius;
    private float _length;
    private Angle _angle;
    private Vector3 _radiusVector;

    public SimpleCurvedCurve(float radius, float length, Angle angle)
    {
        _radius = radius;
        _length = length;
        _angle = angle;
        _radiusVector = Vector3.back * _radius;
    }

    public PositionRotation GetPositionRotation(float distance)
    {
        float ang = distance * _angle.Value / _length;
        Quaternion angle = Quaternion.Euler(0, ang, 0);
        return new PositionRotation()
        {
            Position = _radiusVector - angle * _radiusVector,
            Rotation = angle
        };
    }
}

