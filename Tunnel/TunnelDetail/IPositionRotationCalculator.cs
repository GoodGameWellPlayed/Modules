public interface IPositionRotationCalculator
{
    PositionRotation GetPositionRotation(TunnelDetail detail, TunnelVector3 localPosition);
    PositionRotation GetCentralPoint(TunnelDetail detail, float depth);
}

