using UnityEngine;

public class TunnelDetail : ITunnelDetail
{
    private TunnelDetailCarcas Carcas { get; set; }
    private PositionRotation GlobalStartPoint { get; set; }
    private Angle RotationAroundX { get; set; }
    private Quaternion RotationAroundXQuaternion { get; set; }

    public float Length { get; private set; }

    public TunnelDetail(TunnelDetailCarcas carcas, float length, PositionRotation globalPositionOfStartPoint, Angle rotationAroundX)
    {
        Carcas = carcas;
        Length = length;

        GlobalStartPoint = globalPositionOfStartPoint;
        RotationAroundX = rotationAroundX;
        RotationAroundXQuaternion = Quaternion.Euler(RotationAroundX.Value, 0, 0);
    }

    public PositionRotation GetGlobalPositionRotation(TunnelVector3 localPosition)
    {
        PositionRotation cutPositionRotation = Carcas.TunnelDetailCut.GetLocalPositionRotation(localPosition);
        PositionRotation curvePositionRotation = Carcas.PositionCurve.GetPositionRotation(localPosition.Depth);
        return GlobalStartPoint + ((curvePositionRotation + cutPositionRotation) *
            RotationAroundXQuaternion);
    }

    public float GetCentrailPointHeight(float depth, Angle angle)
    {
        return Carcas.TunnelDetailCut.GetCentrailPointHeight(depth, angle);
    }
}

