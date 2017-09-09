using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoldKeyboardInputControl : KeyboardInputControl<DurationInputArguments>
{
    public KeyHoldKeyboardInputControl(KeyCode keyCode) : base(keyCode)
    {
    }

    protected override bool GetIsControlInherited(KeyCode keyCode, DurationInputArguments arguments = null)
    {
        bool result = Input.GetKey(keyCode);
        if (result)
        {
            arguments.Duration = 10;
        }
        return result;
    }
}
