using UnityEngine;

public class SimpleDetailMap : DetailMap
{
    [SerializeField] private int _count;
    [SerializeField] private float _length;
    [SerializeField] private float _radius;
    [SerializeField] private Angle _angle;

    private ITunnelDetail[] _details;

    private ITunnelDetail[] Details
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
        _details = new ITunnelDetail[_count];
        PositionRotation start = PositionRotation.Identity;
        for (int i = 0; i < _count; i++)
        {
            TunnelDetailCarcas carcas = new TunnelDetailCarcas(new SimpleCut(_radius), 
                new SimpleCurvedCurve(10, _length, new Angle(45))); 
                //new SimpleCurve());
            _details[i] = new TunnelDetail(carcas, _length, start, _angle);
            start = _details[i].GetEndPoint();
        }
    }

    public override ITunnelDetail GetDetail(float depth, out float depthBefore)
    {
        int detailIndex = depth < Length ? (int)(depth / _length) : _count - 1;
        depthBefore = detailIndex <= 0 ? 0 : detailIndex * _length;
        return Details[detailIndex];
    }
}
