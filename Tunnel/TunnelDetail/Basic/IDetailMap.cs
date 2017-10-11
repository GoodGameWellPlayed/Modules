public interface IDetailMap
{
    ITunnelDetail GetDetail(float depth, out float depthBeforeDetail);
    float Length { get; }
}

