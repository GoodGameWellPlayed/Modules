using System.Collections.Generic;

public class InputDictionary : Dictionary<InputAttribute, IInputControl>
{
    public InputDictionary():base(byte.MaxValue)
    {
    }

    public bool GetIsControl<A>(InputAttribute attribute, A arguments) where A : class, IInputArguments
    {
        if (!ContainsKey(attribute))
        {
            return false;
        }
        return this[attribute].GetIsControl(arguments);
    }

    public bool HasControl(IInputControl control)
    {
        foreach (IInputControl c in Values)
        {
            if (c.Equals(control))
            {
                return true;
            }
        }
        return false;
    }
}

