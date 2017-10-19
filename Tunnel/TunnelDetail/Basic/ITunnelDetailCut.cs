public interface ITunnelDetailCut
{
    PositionRotation GetLocalPositionRotation(TunnelVector3 vector);
    float GetCentrailPointHeight(float depth, Angle angle);
}

