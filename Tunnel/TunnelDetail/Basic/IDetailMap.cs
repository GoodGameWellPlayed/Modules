public interface IDetailMap
{
    TunnelDetail GetDetail(float depth, out float localDepth);
    float Length { get; }
    int DetailsCount { get; }
}

