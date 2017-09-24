using UnityEngine;

public class DirectionControlArguments : IDirectionControlArguments
{
    private Vector3 _direction;

    public Vector3 Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
            if (!IsNormalized) { Normalize(); }
        }
    }

    private bool IsNormalized
    {
        get
        {
            return _direction.sqrMagnitude == 1;
        }
    }

    private void Normalize()
    {
        _direction.Normalize();
    }

    public bool IsEmpty
    {
        get
        {
            return _direction == Vector3.zero;
        }
    }
}
