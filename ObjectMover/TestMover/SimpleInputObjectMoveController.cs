using System;
using UnityEngine;

public class SimpleInputObjectMoveController : MonoBehaviorMoveController
{
    private DirectionControlArguments _direction;

    public override ControlArguments GetArguments()
    {
        if (_direction == null)
        {
            _direction = new DirectionControlArguments();
        }
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.x = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.z = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.z = -1;
        }

        if (direction == Vector3.zero)
        {
            return null;
        }

        _direction.Direction = direction;
        return _direction;
    }
}
