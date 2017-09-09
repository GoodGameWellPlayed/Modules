using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardInputControl : InputControl
{
    private KeyCode _keyCode;
    private bool _shouldHold;

    public KeyboardInputControl(KeyCode keyCode)
    {
        _keyCode = keyCode;
    }

    public override bool Equals(object obj)
    {
        return ((obj as KeyboardInputControl)._keyCode == _keyCode) &&
            (obj.GetType().Equals(GetType()));
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool GetIsControl(InputArguments arguments = null)
    {
        if (arguments != null && !arguments.GetType().Equals(ArgumentsTypeExpected))
        {
            ErrorMessages.ArgumentsTypeExpectedMessage(GetType().ToString(), 
                ArgumentsTypeExpected.ToString());
            return false;
        }
        return GetIsControlInherited(_keyCode, arguments);
    }

    protected abstract bool GetIsControlInherited(KeyCode keyCode,
        InputArguments arguments = null);
}
