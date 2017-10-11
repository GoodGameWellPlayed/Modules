using UnityEngine;

public sealed class TunnelTransform : MonoBehaviour
{
    private void Awake()
    {
        enabled = false;
    }

    public TunnelVector3 Position
    {
        get { return _position; }
        set { SetPosition(value); }
    }
    public ITunnel Tunnel
    {
        get { return _tunnel; }
        set { SetTunnel(value); }
    }
    public bool IsInTunnel { get { return _tunnel != null; } }

    private TunnelVector3 _position;
    private ITunnel _tunnel;

    private void SetTunnel(ITunnel tunnel)
    {
        _tunnel = tunnel;
        Position = TunnelVector3.Zero;
    }

    private void SetPosition(TunnelVector3 position)
    {
        if (!IsInTunnel)
        {
            Debug.LogError("Tunnel is not assinged!");
            return;
        }

        if (position.Depth < 0)
        {
            position.Depth = 0;
        }
        if (position.Depth > _tunnel.Length)
        {
            position.Depth = _tunnel.Length;
        }

        _position = position;
        _tunnel.PutInTunnel(transform, Position);
    }
}

