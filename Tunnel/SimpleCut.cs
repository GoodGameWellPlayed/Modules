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
        return new PositionRotation()
        {
            Position = Quaternion.Euler(vector.AngleDegrees.Value, 0, 0) * (Vector3.down * (_radius - vector.Height)),
            Rotation = Quaternion.Euler(vector.AngleDegrees.Value, 0, 0)
        };
    }
}
