using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDictionary<T> : Dictionary<InputAttribute, IInputControl<T>> where T : InputArguments
{
    public InputDictionary():base(byte.MaxValue)
    {
    }

    public bool GetIsControl(InputAttribute attribute, T arguments = null)
    {
        if (!ContainsKey(attribute))
        {
            return false;
        }
        return this[attribute].GetIsControl(arguments);
    }

    public bool HasControl(IInputControl<T> control)
    {
        foreach (IInputControl<T> c in Values)
        {
            if (c.Equals(control))
            {
                return true;
            }
        }
        return false;
    }
}
