using UnityEngine;

public class SimpleDetailMap : DetailMap
{
    [SerializeField] private int _count;
    [SerializeField] private float _length;
    [SerializeField] private float _radius;
    [SerializeField] private Angle _angle;

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
        TunnelDetailCarcas carcas = new TunnelDetailCarcas(new SimpleCut(_radius), 
            //new SimpleCurvedCurve(10, _length, new Angle(45))); 
            new SimpleCurve());

        for (int i = 0; i < _count; i++)
        {
            GameObject detail = new GameObject("TUNNEL " + i);
            detail.transform.position = start.Position;
            detail.transform.rotation = start.Rotation;

            _details[i] = new TunnelDetail(carcas, _length, start, _angle);
            start = calculator.GetEndPoint(_details[i]);
        }
    }

    public override TunnelDetail GetDetail(float depth, out float depthBefore)
    {
        int detailIndex = depth < Length ? (int)(depth / _length) : _count - 1;
        depthBefore = detailIndex <= 0 ? 0 : detailIndex * _length;
        return Details[detailIndex];
    }
}
