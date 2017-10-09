public interface ITunnelDetail
{
    PositionRotation GetGlobalPositionRotation(TunnelVector3 localPosition);
    float GetCentrailPointHeight(float depth, Angle angle);
    float Length { get; }
}

