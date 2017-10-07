using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TunnelTransform : Component
{
    public TunnelVector3 LocalPosition { get { return _localPosition; } }
    public TunnelVector3 GlobalPosition { get { return _localPosition; } }
    public ITunnelDetail Detail { get; private set; }
    public ITunnel Tunnel { get; private set; }

    private TunnelVector3 _localPosition;

    public bool IsInTunnel
    {
        get
        {
            return Tunnel != null;
        }
    }

    public void PutInTunnel(ITunnel tunnel, TunnelVector3 globalPosition)
    {
        
    }

    public bool Move(TunnelVector3 speed)
    {
        if (IsInTunnel)
        {

        }
        return false;
    }
}

