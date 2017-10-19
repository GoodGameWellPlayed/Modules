using UnityEngine;

public class SimplePositionRotationCalculator : IPositionRotationCalculator
{
    public PositionRotation GetCentralPoint(TunnelDetail detail, float depth)
    {
        Quaternion beginning = Quaternion.Euler(detail.RotationAtTheBeginning.Value, 0, 0);
        Quaternion beginningReversed = Quaternion.Euler(-detail.RotationAtTheBeginning.Value, 0, 0);

        PositionRotation local = beginning * detail.PositionCurve.GetPositionRotation(depth);
        local.Rotation *= beginningReversed;

        return detail.GlobalStartPoint + local;
    }

    public PositionRotation GetPositionRotation(TunnelDetail detail, TunnelVector3 localPosition)
    {
        PositionRotation cutPositionRotation = detail.TunnelDetailCut.GetLocalPositionRotation(localPosition);
        PositionRotation curvePositionRotation = GetCentralPoint(detail, localPosition.Depth);
        return curvePositionRotation + cutPositionRotation;
    }
}

