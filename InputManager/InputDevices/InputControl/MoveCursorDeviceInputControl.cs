using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursorDeviceInputControl<D> : DeviceInputControl<IPositionInputArguments, D>
    where D : IInputDevicePositioned
{
    public MoveCursorDeviceInputControl(D device) : base(device)
    {
    }

    public override bool GetIsControl(IPositionInputArguments arguments = null)
    {
        Vector3 position;
        bool result = Device.IsCursorMoved(out position);
        arguments.Position = position;
        return result;
    }
}
