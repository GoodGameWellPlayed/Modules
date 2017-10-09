using UnityEngine;

public class SimpleCurve : IPositionCurve
{
    public PositionRotation GetPositionRotation(float distance)
    {
        return new PositionRotation()
        {
            Position = new Vector3(distance, 0, 0),
            Rotation = Quaternion.identity
        };
    }
}

