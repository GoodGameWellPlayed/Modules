﻿using UnityEngine;
using UnityEngine.Profiling;

public class DetailedTunnel : ITunnel
{
    private IDetailMap _detailMap;
    private IPositionRotationCalculator _positionRotationCalculator;

    public DetailedTunnel(IDetailMap detailMap, IPositionRotationCalculator positionRotationCalculator)
    {
        _detailMap = detailMap;
        _positionRotationCalculator = positionRotationCalculator;
    }

    public float Length
    {
        get
        {
            return _detailMap.Length;
        }
    }

    public void PutInTunnel(Transform transform, TunnelVector3 globalPosition)
    {
        float localDepth;
        TunnelDetail detail = _detailMap.GetDetail(globalPosition.Depth, out localDepth);
        globalPosition.Depth = localDepth;
        PositionRotation position = _positionRotationCalculator.GetPositionRotation(detail, globalPosition);
        position.SetPosition(transform);
    }

    public void PutInCenter(Transform transform, float depth)
    {
        float localDepth;
        TunnelDetail detail = _detailMap.GetDetail(depth, out localDepth);
        PositionRotation position = _positionRotationCalculator.GetCentralPoint(detail, localDepth);
        position.SetPosition(transform);
    }
}

