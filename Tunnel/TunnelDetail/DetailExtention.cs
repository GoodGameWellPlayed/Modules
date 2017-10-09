using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DetailExtention
{
    public static PositionRotation GetEndPoint(this ITunnelDetail detail)
    {
        Angle angle = new Angle();
        float depth = detail.Length;
        float height = detail.GetCentrailPointHeight(depth, angle);
        return detail.GetGlobalPositionRotation(new TunnelVector3(depth, angle, height));
    }
}

