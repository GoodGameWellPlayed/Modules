public class TunnelDetailCarcas
{
    private ITunnelDetailCut TunnelDetailCut { get; set; }
    private IPositionCurve PositionCurve { get; set; }
    private ITunnelRails TunnelRails { get; set; }

    public TunnelDetailCarcas(ITunnelDetailCut tunnelDetailCut,
                              IPositionCurve positionCurve,
                              ITunnelRails tunnelRails)
    {
        TunnelDetailCut = tunnelDetailCut;
        PositionCurve = positionCurve;
        TunnelRails = tunnelRails;
    }

    public PositionRotation GetPositionRotation(TunnelVector3 localPosition)
    {
        PositionRotation localPositionRotation = TunnelDetailCut.GetLocalPositionRotation(localPosition);
        PositionRotation globalPositionRotation = PositionCurve.GetPositionRotation(localPosition.Depth);
        return globalPositionRotation + localPositionRotation;
    }

    public PositionRotation EndPoint
    {
        get
        {
            return PositionCurve.GetPositionRotation(PositionCurve.Length);
        }
    }
}

