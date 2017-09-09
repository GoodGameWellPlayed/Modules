using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoldKeyboardInputControl : KeyboardInputControl
{
    public KeyHoldKeyboardInputControl(KeyCode keyCode) : base(keyCode)
    {
    }

    protected override bool GetIsControlInherited(KeyCode keyCode, InputArguments arguments = null)
    {
        bool result = Input.GetKey(keyCode);
        if (result)
        {
            arguments as 
        }
    }
}
