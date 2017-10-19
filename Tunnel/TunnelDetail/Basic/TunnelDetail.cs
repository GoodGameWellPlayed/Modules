public class TunnelDetail
{
    public ITunnelDetailCut TunnelDetailCut { get; private set; }
    public IPositionCurve PositionCurve { get; private set; }
    public PositionRotation GlobalStartPoint { get; private set; }
    public float Length { get; private set; }
    public Angle RotationAtTheBeginning { get; private set; }

    public TunnelDetail(ITunnelDetailCut tunnelDetailCut,
                        IPositionCurve positionCurve,
                        PositionRotation startPoint,
                        float length,
                        Angle rotationAtTheBeginning)
    {
        TunnelDetailCut = tunnelDetailCut;
        PositionCurve = positionCurve;
        GlobalStartPoint = startPoint;
        Length = length;
        RotationAtTheBeginning = rotationAtTheBeginning;
    }
}

