using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenPositionInputControl<T> : IInputControl<T> where T : InputArguments, IPositionInputArguments
{
    public bool GetIsControl(T arguments = null)
    {
        Vector3 position;
        bool result = InheritedGetIsControl(out position, arguments);
        arguments.Position = position;
        return result;
    }

    protected abstract bool InheritedGetIsControl(out Vector3 position, T arguments = null);
}
