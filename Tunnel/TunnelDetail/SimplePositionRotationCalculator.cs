using System.Collections.Generic;
using UnityEngine;

public class SimplePositionRotationCalculator : IPositionRotationCalculator
{
    public PositionRotation GetEndPoint(TunnelDetail detail)
    {
        PositionRotation curvePositionRotation = detail.Carcas.PositionCurve.GetPositionRotation(detail.Length);
        return detail.GlobalStartPoint + curvePositionRotation;
    }

    public PositionRotation GetPositionRotation(TunnelDetail detail, TunnelVector3 localPosition)
    {
        localPosition.AngleDegrees -= detail.TunnelXOffset;
        PositionRotation cutPositionRotation = detail.Carcas.TunnelDetailCut.GetLocalPositionRotation(localPosition);
        PositionRotation curvePositionRotation = detail.Carcas.PositionCurve.GetPositionRotation(localPosition.Depth);
        return detail.GlobalStartPoint + (curvePositionRotation + cutPositionRotation);
    }
}

