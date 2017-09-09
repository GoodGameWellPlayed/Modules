using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputDevice : InputDevice, IInputDeviceClickable,
    IInputDevicePositioned, IInputDeviceHoldable
{
    private Vector3 _lastMousePosition = Vector3.zero;

    public bool IsCursorMoved(out Vector3 cursorPosition)
    {
        cursorPosition = Input.mousePosition;
        if (_lastMousePosition != cursorPosition)
        {
            _lastMousePosition = cursorPosition;
            return true;
        }
        return false;
    }

    public bool IsHolding(object buttonIdentifier)
    {
        return Input.GetMouseButton((int)(buttonIdentifier));
    }

    public bool IsPressed(object buttonIdentifier)
    {
        return Input.GetMouseButtonDown((int)(buttonIdentifier));
    }

    public bool IsReleased(object buttonIdentifier)
    {
        return Input.GetMouseButtonUp((int)(buttonIdentifier));
    }
}

public enum MouseButtons : int
{
    Left = 0,
    Right = 1,
    Middle = 2
}
