public interface IInputDeviceClickable<I> : IInputDevice
{
    bool IsPressed(I buttonIdentifier);

    bool IsReleased(I buttonIdentifier);
}

