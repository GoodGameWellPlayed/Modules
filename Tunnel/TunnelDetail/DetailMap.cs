using UnityEngine;

public abstract class DetailMap : MonoBehaviour, IDetailMap
{
    public abstract float Length { get; }

    public abstract ITunnelDetail GetDetail(float depth, out float depthBefore);
}
