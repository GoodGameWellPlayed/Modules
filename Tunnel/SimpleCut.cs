using UnityEngine;

public class SimpleCut : ITunnelDetailCut
{
    private float _radius;

    public SimpleCut(float radius)
    {
        _radius = radius;
    }

    public float GetCentrailPointHeight(float depth, Angle angle)
    {
        return _radius;
    }

    public PositionRotation GetLocalPositionRotation(TunnelVector3 vector)
    {
        Quaternion rotation = Quaternion.Euler(vector.AngleDegrees.Value, 0, 0);
        return new PositionRotation()
        {
            Position = rotation * (Vector3.down * (_radius - vector.Height)),
            Rotation = rotation
        };
    }
}
