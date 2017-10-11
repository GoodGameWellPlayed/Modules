using UnityEngine;

public class DetailedTunnel : MonoBehaviour, ITunnel
{
    //[SerializeField] private MonoBehaviour _detailMap;
    [SerializeField] private DetailMap _detailMap;

    public float Length
    {
        get
        {
            return _detailMap.Length;
        }
    }

    public void PutInTunnel(Transform transform, TunnelVector3 globalPosition)
    {
        float depthBefore;

        ITunnelDetail detail = _detailMap.GetDetail(globalPosition.Depth, out depthBefore);
        globalPosition.Depth = globalPosition.Depth - depthBefore;
        PositionRotation position = detail.GetGlobalPositionRotation(globalPosition);
        position.SetPosition(transform);
    }
}

