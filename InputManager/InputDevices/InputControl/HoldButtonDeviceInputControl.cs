using System;
using UnityEngine;

public class HoldButtonDeviceInputControl<D, I> : DeviceInputControl<D>
    where D : IInputDeviceHoldable<I>
{
    private I _buttonIdentifier;

    public HoldButtonDeviceInputControl(D device, I buttonIdentifier) : base(device)
    {
        _buttonIdentifier = buttonIdentifier;
    }

    public override bool GetIsControl<A>(A arguments)
    {
        return Device.IsHolding(_buttonIdentifier);
    }
}

public interface IInputTimer : IResetable
{
    void Start();
    void Stop();
    TimeSpan TimePassed { get; }
    bool IsRunning { get; }
}

public class HoldDurationDeviceInputControl<D, I, T> : HoldButtonDeviceInputControl<D, I>
    where D : IInputDeviceHoldable<I> where T : class, IInputTimer, new()
{
    private T _timer;

    public HoldDurationDeviceInputControl(D device, I buttonIdentifier) : base(device, buttonIdentifier)
    {
        _timer = new T();
    }

    public override bool GetIsControl<A>(A arguments)
    {
        bool isControl = base.GetIsControl(arguments);
        if (arguments != null)
        {
            if (arguments is IDurationInputArguments)
            {
                (arguments as IDurationInputArguments).Duration = GetDuration(isControl);
            }
        }
        return isControl;
    }

    private float GetDuration(bool isControl)
    {
        if (isControl)
        {
            if (!_timer.IsRunning)
            {
                _timer.Start();
            }
            else
            {
                return (float)_timer.TimePassed.TotalSeconds;
            }
        }
        else
        {
            if (_timer.IsRunning)
            {
                _timer.Stop();
                _timer.Reset();
            }
        }
        return 0;
    }
}

