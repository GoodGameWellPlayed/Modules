using UnityEngine;

public interface IInputDevicePositioned : IInputDevice
{
    bool IsCursorMoving();

    void GetCursorPosition(IPositionInputArguments arguments);
}

public interface IInputDevicePositioned<I> : IInputDevice
{
    bool IsCursorMoving(I cursorIdentifier);

    void GetCursorPosition(I cursorIdentifier, IPositionInputArguments arguments);
}

