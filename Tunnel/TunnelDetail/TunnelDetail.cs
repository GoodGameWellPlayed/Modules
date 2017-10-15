using UnityEngine;

public class TunnelDetail
{
    public TunnelDetailCarcas Carcas { get; private set; }
    public float Length { get; private set; }
    public PositionRotation GlobalStartPoint { get; set; }
    public Angle TunnelXOffset { get; set; }

    public TunnelDetail(TunnelDetailCarcas carcas, float length, PositionRotation globalStartPoint, Angle rotationAroundX)
    {
        Carcas = carcas;
        Length = length;

        globalStartPoint.Rotation *= Quaternion.Euler(rotationAroundX.Value, 0, 0);
        GlobalStartPoint = globalStartPoint;
        TunnelXOffset = rotationAroundX;
    }

    public TunnelVector3 CenterPoint(float depth)
    {
        return new TunnelVector3(depth, Angle.Zero, Carcas.TunnelDetailCut.GetCentrailPointHeight(depth, Angle.Zero));
    }
}

