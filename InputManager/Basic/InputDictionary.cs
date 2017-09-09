using System.Collections.Generic;
using UnityEngine;

public class InputDictionary
{
    protected static Dictionary<InputAttribute, InputControl> _dictionary;

    public InputDictionary()
    {
        _dictionary = new Dictionary<InputAttribute, InputControl>(10);
    }

    public bool GetIsControl(InputAttribute attribute, InputArguments arguments = null)
    {
        if (!_dictionary.ContainsKey(attribute))
        {
            return false;
        }
        return _dictionary[attribute].GetIsControl(arguments);
    }

    public bool HasControl(InputControl control)
    {
        foreach (InputControl c in _dictionary.Values)
        {
            if (c.Equals(control))
            {
                return true;
            }
        }
        return false;
    }

    public void Add(InputAttribute attribute, InputControl control)
    {
        if (_dictionary.ContainsKey(attribute))
        {
            Debug.LogError("InputAttribute " + attribute.Name + " is already in a dictionary");
        }
        else
        {
            _dictionary.Add(attribute, control);
        }
    }
}
