using System;
using UnityEngine;

public class SimpleInputObjectMoveController : MonoBehaviorMoveController
{
    private DirectionControlArguments _direction;

    private InputAttribute Up { get { return InputAttributesSet.WalkUp; } }
    private InputAttribute Down { get { return InputAttributesSet.WalkDown; } }
    private InputAttribute Left { get { return InputAttributesSet.WalkLeft; } }
    private InputAttribute Right { get { return InputAttributesSet.WalkRight; } }

    public override IControlArguments GetArguments()
    {
        if (_direction == null)
        {
            _direction = new DirectionControlArguments();
        }
        Vector3 direction = Vector3.zero;

        if (InputManager.Instance.GetIsControl(Up))
        {
            direction.y = 1;
        }
        if (InputManager.Instance.GetIsControl(Down))
        {
            direction.y = -1;
        }
        if (InputManager.Instance.GetIsControl(Right))
        {
            direction.x = 1;
        }
        if (InputManager.Instance.GetIsControl(Left))
        {
            direction.x = -1;
        }

        if (direction == Vector3.zero)
        {
            return null;
        }

        _direction.Direction = direction;
        return _direction;
    }
}
