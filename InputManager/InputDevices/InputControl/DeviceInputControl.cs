public abstract class DeviceInputControl<D> : IInputControl where D : IInputDevice
{
    protected D Device { get; private set; }

    public DeviceInputControl(D device)
    {
        Device = device;
    }

    public abstract bool GetIsControl<A>(A arguments) where A : class, IInputArguments;
}
