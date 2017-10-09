using UnityEngine;

public class DetailedTunnel : MonoBehaviour, ITunnel
{
    //[SerializeField] private MonoBehaviour _detailMap;
    [SerializeField] private DetailMap _detailMap;

    public void PutInTunnel(Transform transform, TunnelVector3 globalPosition)
    {
        PositionRotation position = (_detailMap as IDetailMap).GetDetail(globalPosition.Depth).GetGlobalPositionRotation(globalPosition);
        position.SetPosition(transform);
    }
}

