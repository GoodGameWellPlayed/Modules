using UnityEngine;

public struct PositionRotation
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }

    public static PositionRotation operator +(PositionRotation global, PositionRotation local)
    {
        Vector3 position = global.Position + global.Rotation * local.Position;
        Quaternion rotation = global.Rotation * local.Rotation;
        return new PositionRotation()
        {
            Position = position,
            Rotation = rotation
        };
    }

    public void SetPosition(Transform transform)
    {
        transform.localPosition = Position;
        transform.localRotation = Rotation;
    }
}

