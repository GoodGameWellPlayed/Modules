public interface IPositionRotationCalculator
{
    PositionRotation GetPositionRotation(TunnelDetail detail, TunnelVector3 localPosition);
    PositionRotation GetEndPoint(TunnelDetail detail);
}

