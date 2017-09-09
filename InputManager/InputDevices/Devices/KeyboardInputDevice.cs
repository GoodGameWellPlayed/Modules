using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputDevice : InputDevice, IInputDeviceClickable, IInputDeviceHoldable
{
    public bool IsHolding(object buttonIdentifier)
    {
        return Input.GetKey((KeyCode)buttonIdentifier);
    }

    public bool IsPressed(object buttonIdentifier)
    {
        return Input.GetKeyDown((KeyCode)buttonIdentifier);
    }

    public bool IsReleased(object buttonIdentifier)
    {
        return Input.GetKeyUp((KeyCode)buttonIdentifier);
    }
}
