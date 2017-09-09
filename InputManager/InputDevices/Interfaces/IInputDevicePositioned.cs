using UnityEngine;

public interface IInputDevicePositioned : IInputDevice
{
    bool IsCursorMoved(out Vector3 cursorPosition);
}

public interface IInputDevicePositioned<I> : IInputDevice
{
    bool IsCursorMoved(I cursorIdentifier, out Vector3 cursorPosition);
}

