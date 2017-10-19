using UnityEngine;

public class SimpleCurvedCurve : IPositionCurve
{
    private float _radius;

    public SimpleCurvedCurve(float radius)
    {
        _radius = radius;
    }

    public PositionRotation GetPositionRotation(float distance)
    {
        Vector3 radius = Vector3.back * _radius;
        float ang = distance * 180f / (Mathf.PI * _radius);
        Quaternion rotation = Quaternion.Euler(0, ang, 0);
        return new PositionRotation()
        {
            Position = radius - (rotation * radius),
            Rotation = rotation
        };
    }
}

