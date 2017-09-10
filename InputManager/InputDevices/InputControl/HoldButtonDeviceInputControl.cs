﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtonDeviceInputControl<D, I> : DeviceInputControl<D>
    where D : IInputDeviceHoldable<I>
{
    private I _buttonIdentifier;

    public HoldButtonDeviceInputControl(D device, I buttonIdentifier) : base(device)
    {
        _buttonIdentifier = buttonIdentifier;
    }

    public override bool GetIsControl<A>(A arguments)
    {
        //todo timer
        return Device.IsHolding(_buttonIdentifier);
    }
}
