using UnityEngine;

public class SimpleDetailMap : DetailMap
{
    [SerializeField] private int _count;
    [SerializeField] private float _length;
    [SerializeField] private float _radius;

    public override int DetailsCount
    {
        get
        {
            return _count;
        }
    }

    private TunnelDetail[] _details;

    private TunnelDetail[] Details
    {
        get
        {
            if (_details == null)
            {
                FillDetails();
            }
            return _details;
        }
    }

    public override float Length
    {
        get { return _length * _count; }
    }

    private void FillDetails()
    {
        _details = new TunnelDetail[_count];
        IPositionRotationCalculator calculator = new SimplePositionRotationCalculator();

        PositionRotation start = PositionRotation.Identity;
        ITunnelDetailCut cut = new SimpleCut(_radius);

        IPositionCurve[] curves = new IPositionCurve[3];
        curves[0] = new SimpleCurvedCurve(10);
        curves[1] = new SimpleCurvedCurve(30);
        curves[2] = new SimpleCurve();

        for (int i = 0; i < _count; i++)
        {
            _details[i] = new TunnelDetail(cut, curves[i % curves.Length], start, _length, new Angle(Random.Range(0, 360f)));
            start = calculator.GetCentralPoint(_details[i], _details[i].Length);
        }
    }

    public override TunnelDetail GetDetail(float depth, out float localDepth)
    {
        int detailIndex = depth < Length ? (int)(depth / _length) : _count - 1;
        localDepth = depth % _length;
        return Details[detailIndex];
    }
}
