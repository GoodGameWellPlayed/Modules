using System;

public abstract class DurationInputControl : InputControl
{
    public override bool GetIsControl(InputArguments arguments)
    {
        bool result = false;
        if (IsControlInherited)
        {
            if (Timer == default(ITimer))
            {
                CreateAndSetTimer();
            }
        }
        else
        {
            if (Timer != default(ITimer))
            {
                result = Timer.TimePassedFromStart.TotalSeconds >= Duration;
                Timer.Stop();
                Timer = default(ITimer);
            }
        }
        return result;
    }

    protected abstract void CreateAndSetTimer();

    protected abstract float Duration { get; }

    protected abstract bool IsControlInherited { get; }

    protected abstract ITimer Timer { get; set; }
}
