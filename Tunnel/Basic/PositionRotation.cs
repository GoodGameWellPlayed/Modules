using UnityEngine;

public struct PositionRotation
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }

    public static PositionRotation Identity = new PositionRotation()
    {
        Position = Vector3.zero,
        Rotation = Quaternion.identity
    };

    public void SetPosition(Transform transform)
    {
        transform.localPosition = Position;
        transform.localRotation = Rotation;
    }

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

    public static PositionRotation operator *(PositionRotation position, Quaternion rotation)
    {
        return new PositionRotation()
        {
            Position = rotation * position.Position,
            Rotation = rotation * position.Rotation
        };
    }

    public override string ToString()
    {
        return "Position : " + Position + "; Rotation : " + Rotation.eulerAngles;
    }
}

