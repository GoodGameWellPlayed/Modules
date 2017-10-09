using UnityEngine;

public class SimpleDetailMap : DetailMap
{
    [SerializeField] private int _count;
    [SerializeField] private float _length;
    [SerializeField] private float _radius;
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

    private void FillDetails()
    {
        _details = new ITunnelDetail[_count];
        PositionRotation start = PositionRotation.Identity;
        for (int i = 0; i < _count; i++)
        {
            TunnelDetailCarcas carcas = new TunnelDetailCarcas(new SimpleCut(_radius), new SimpleCurve(), null);
            _details[i] = new TunnelDetail(carcas, _length, start, new Angle());
            start = _details[i].GetEndPoint();
        }
    }

    public override ITunnelDetail GetDetail(float depth)
    {
        return _details[(int)(depth / _length)];
    }
}
