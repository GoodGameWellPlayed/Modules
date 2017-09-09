using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDeviceInputControl<A, D> : DeviceInputControl<A, D>
    where A : InputArguments, IDurationInputArguments where D : InputDevice
{
    public HoldDeviceInputControl(D device) : base(device)
    {
    }

    public override bool GetIsControl(A arguments = null)
    {
        arguments.Duration = Device.
    }
}
