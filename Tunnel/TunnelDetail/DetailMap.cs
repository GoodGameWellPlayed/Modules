using UnityEngine;

public abstract class DetailMap : MonoBehaviour, IDetailMap
{
    public abstract ITunnelDetail GetDetail(float depth);
}
