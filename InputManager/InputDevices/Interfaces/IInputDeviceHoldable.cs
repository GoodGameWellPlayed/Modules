public interface IInputDeviceHoldable<I> : IInputDevice
{
    bool IsHolding(I buttonIdentifier);
}

