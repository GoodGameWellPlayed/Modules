using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionControlArguments : ControlArguments
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
            return (Mathf.Abs(_direction.x) == 1 || _direction.x == 0) &&
                   (Mathf.Abs(_direction.y) == 1 || _direction.y == 0) &&
                   (Mathf.Abs(_direction.z) == 1 || _direction.z == 0);
        }
    }

    private void Normalize()
    {
        _direction.x = _direction.x == 0 ? 0 : Mathf.Abs(_direction.x) / _direction.x;
        _direction.y = _direction.y == 0 ? 0 : Mathf.Abs(_direction.y) / _direction.y;
        _direction.z = _direction.z == 0 ? 0 : Mathf.Abs(_direction.z) / _direction.z;
    }

    public bool IsEmpty
    {
        get
        {
            return _direction == Vector3.zero;
        }
    }
}
