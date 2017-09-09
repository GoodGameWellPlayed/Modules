using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceInputControl<A, D> : IInputControl<A>
    where A : class, IInputArguments where D : IInputDevice
{
    protected D Device { get; private set; }

    public DeviceInputControl(D device)
    {
        Device = device;
    }

    public abstract bool GetIsControl(A arguments);
}
