using UnityEngine;

public interface IInputDevicePositioned : IInputDevice
{
    bool IsCursorMoved();

    Vector3 CursorPosition { get; }
}

public interface IInputDevicePositioned<I> : IInputDevice
{
    bool IsCursorMoved(I cursorIdentifier, out Vector3 cursorPosition);
}

