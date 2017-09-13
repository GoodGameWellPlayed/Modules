using UnityEngine;

public interface IInputDevicePositioned : IInputDevice
{
    bool IsCursorMoving();

    Vector3 CursorPosition { get; }
}

public interface IInputDevicePositioned<I> : IInputDevice
{
    bool IsCursorMoved(I cursorIdentifier, out Vector3 cursorPosition);
}

