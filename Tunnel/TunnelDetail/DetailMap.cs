using UnityEngine;

public abstract class DetailMap : MonoBehaviour, IDetailMap
{
    public abstract float Length { get; }
    public abstract TunnelDetail GetDetail(float depth, out float localDepth);
    public abstract int DetailsCount { get; }
}
