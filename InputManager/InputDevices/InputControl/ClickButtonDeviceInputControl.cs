public class ClickButtonDeviceInputControl<D, I> : DeviceInputControl<EmptyInputArguments, D>
    where D : IInputDeviceClickable<I>
{
    private I _buttonIdentifier;
    private ControlType _controlType;

    public ClickButtonDeviceInputControl(D device, I buttonIdentifier, ControlType controlType = ControlType.Press) 
        : base(device)
    {
        _buttonIdentifier = buttonIdentifier;
        _controlType = controlType;
    }

    public override bool GetIsControl(EmptyInputArguments arguments = null)
    {
        if (_controlType == ControlType.Press)
        {
            return Device.IsPressed(_buttonIdentifier);
        }
        return Device.IsReleased(_buttonIdentifier);
    }
}

public enum ControlType
{
    Press,
    Release
}
