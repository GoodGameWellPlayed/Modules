using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursorDeviceInputControl<D> : DeviceInputControl<D>
    where D : IInputDevicePositioned
{
    public MoveCursorDeviceInputControl(D device) : base(device)
    {
    }

    public override bool GetIsControl<A>(A arguments)
    {
        if (arguments != null && !arguments.GetType().Equals(typeof(IPositionInputArguments)))
        {
            Debug.LogError(ErrorMessages.ArgumentsTypeExpectedMessage(GetType().Name, 
                typeof(IPositionInputArguments).Name));
            return false;
        }

        Vector3 position;
        bool result = Device.IsCursorMoved(out position);
        if (arguments != null)
        {
            (arguments as IPositionInputArguments).Position = position;
        }
        return result;
    }
}
