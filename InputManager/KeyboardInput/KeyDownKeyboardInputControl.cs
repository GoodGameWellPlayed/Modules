using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDownKeyboardInputControl : KeyboardInputControl
{
    private KeyPressType _keyPressType;

    public KeyDownKeyboardInputControl(KeyCode keyCode, 
        KeyPressType keyPressType = KeyPressType.Press) : base(keyCode)
    {
        keyPressType = _keyPressType;
    }

    protected override bool GetIsControlInherited(KeyCode keyCode, InputArguments arguments = null)
    {
        switch (_keyPressType)
        {
            case KeyPressType.Press: return Input.GetKeyDown(keyCode);
            case KeyPressType.Release: return Input.GetKeyUp(keyCode);
        }
        return false;
    }
}

public enum KeyPressType
{
    Press,
    Release
}

