using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardInputControl<T> : IInputControl<T> where T : InputArguments
{
    private KeyCode _keyCode;
    private bool _shouldHold;

    public KeyboardInputControl(KeyCode keyCode)
    {
        _keyCode = keyCode;
    }

    public override bool Equals(object obj)
    {
        return (obj is KeyboardInputControl<T>) && ((obj as KeyboardInputControl<T>)._keyCode == _keyCode);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public bool GetIsControl(T arguments = null)
    {
        return GetIsControlInherited(_keyCode, arguments);
    }

    protected abstract bool GetIsControlInherited(KeyCode keyCode,
        T arguments = null);
}
