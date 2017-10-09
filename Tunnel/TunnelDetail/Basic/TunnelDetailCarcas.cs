public class TunnelDetailCarcas
{
    public ITunnelDetailCut TunnelDetailCut { get; private set; }
    public IPositionCurve PositionCurve { get; private set; }
    public ITunnelRails TunnelRails { get; private set; }

    public TunnelDetailCarcas(ITunnelDetailCut tunnelDetailCut,
                              IPositionCurve positionCurve,
                              ITunnelRails tunnelRails)
    {
        TunnelDetailCut = tunnelDetailCut;
        PositionCurve = positionCurve;
        TunnelRails = tunnelRails;
    }
}

