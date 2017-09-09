using System;
using UnityEngine;

public class SimpleInputObjectMoveController : MonoBehaviorMoveController
{
    private DirectionControlArguments _direction;

    private InputAttribute Up { get { return InputAttributesSet.WalkUp; } }
    private InputAttribute Down { get { return InputAttributesSet.WalkDown; } }
    private InputAttribute Left { get { return InputAttributesSet.WalkLeft; } }
    private InputAttribute Right { get { return InputAttributesSet.WalkRight; } }

    public override ControlArguments GetArguments()
    {
        if (_direction == null)
        {
            _direction = new DirectionControlArguments();
        }
        Vector3 direction = Vector3.zero;

        if (InputManager.Instance.GetIsControl<EmptyInputArguments>(Up))
        {
            direction.y = 1;
        }
        if (InputManager.Instance.GetIsControl<EmptyInputArguments>(Down))
        {
            direction.y = -1;
        }
        if (InputManager.Instance.GetIsControl<EmptyInputArguments>(Right))
        {
            direction.x = 1;
        }
        if (InputManager.Instance.GetIsControl<EmptyInputArguments>(Left))
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
