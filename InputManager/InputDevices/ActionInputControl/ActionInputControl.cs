using System;

public class ActionInputControl : IInputControl
{
    Func<IInputArguments, bool> _inputAction;

    public ActionInputControl(Func<IInputArguments, bool> inputAction)
    {
        _inputAction = inputAction;
    }

    bool IInputControl.GetIsControl<A>(A arguments)
    {
        return _inputAction(arguments);
    }
}

