public class TunnelDetailCarcas
{
    public ITunnelDetailCut TunnelDetailCut { get; private set; }
    public IPositionCurve PositionCurve { get; private set; }

    public TunnelDetailCarcas(ITunnelDetailCut tunnelDetailCut,
                              IPositionCurve positionCurve)
    {
        TunnelDetailCut = tunnelDetailCut;
        PositionCurve = positionCurve;
    }
}

