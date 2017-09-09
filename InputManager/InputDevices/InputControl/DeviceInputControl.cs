using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceInputControl<A, D> : IInputControl<A>
    where A : InputArguments where D : InputDevice
{
    protected D Device { get; private set; }

    public DeviceInputControl(D device)
    {
        Device = device;
    }

    public abstract bool GetIsControl(A arguments = null);
}
