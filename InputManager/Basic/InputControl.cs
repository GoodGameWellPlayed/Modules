using System;

public abstract class InputControl
{
    public abstract bool GetIsControl(InputArguments arguments = null);

    public virtual Type ArgumentsTypeExpected
    {
        get
        {
            return typeof(InputArguments);
        }
    }
}
