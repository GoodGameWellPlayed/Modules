using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputDevice : IInputDeviceClickable<KeyCode>, IInputDeviceHoldable<KeyCode>
{
    public bool IsHolding(KeyCode buttonIdentifier)
    {
        return Input.GetKey(buttonIdentifier);
    }

    public bool IsPressed(KeyCode buttonIdentifier)
    {
        return Input.GetKeyDown(buttonIdentifier);
    }

    public bool IsReleased(KeyCode buttonIdentifier)
    {
        return Input.GetKeyUp(buttonIdentifier);
    }
}
