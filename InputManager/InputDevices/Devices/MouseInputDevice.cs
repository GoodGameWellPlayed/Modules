using UnityEngine;

public class MouseInputDevice : IInputDeviceClickable<MouseButtons>,
    IInputDevicePositioned, IInputDeviceHoldable<MouseButtons>
{
    private Vector3 _lastMousePosition = Vector3.zero;

    private Vector3 CursorPosition
    {
        get
        {
            return Input.mousePosition;
        }
    }

    public void GetCursorPosition(IPositionInputArguments arguments)
    {
        arguments.Position = CursorPosition;
    }

    public bool IsCursorMoving()
    {
        Vector3 cursorPosition = CursorPosition;
        if (_lastMousePosition != cursorPosition)
        {
            _lastMousePosition = cursorPosition;
            return true;
        }
        return false;
    }

    public bool IsHolding(MouseButtons buttonIdentifier)
    {
        return Input.GetMouseButton((int)(buttonIdentifier));
    }

    public bool IsPressed(MouseButtons buttonIdentifier)
    {
        return Input.GetMouseButtonDown((int)(buttonIdentifier));
    }

    public bool IsReleased(MouseButtons buttonIdentifier)
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

