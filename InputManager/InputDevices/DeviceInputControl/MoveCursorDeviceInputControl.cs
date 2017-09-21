public class MoveCursorDeviceInputControl<D> : DeviceInputControl<D>
    where D : IInputDevicePositioned
{
    public MoveCursorDeviceInputControl(D device) : base(device)
    {
    }

    public override bool GetIsControl<A>(A arguments)
    {
        if (arguments != null)
        {
            if (arguments is IPositionInputArguments)
            {
                Device.GetCursorPosition(arguments as IPositionInputArguments);
            }
        }
        return Device.IsCursorMoving();
    }
}
