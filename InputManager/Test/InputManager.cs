using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Dictionary<Type, object> _commonDictionary;

    private void Start()
    {
        _commonDictionary = new Dictionary<Type, object>();

        //filling dictionary without arguments
        _commonDictionary.Add(typeof(InputArguments), new InputDictionary<InputArguments>
        {
            { InputAttributesSet.WalkDown, new KeyDownKeyboardInputControl(KeyCode.W) },
            { InputAttributesSet.WalkLeft, new KeyDownKeyboardInputControl(KeyCode.LeftArrow) },
            { InputAttributesSet.WalkRight, new KeyDownKeyboardInputControl(KeyCode.RightArrow) },
            { InputAttributesSet.WalkUp, new KeyDownKeyboardInputControl(KeyCode.UpArrow) }
        });

        //filling dictionary with Duration argument
        _commonDictionary.Add(typeof(PositionInputArguments), new InputDictionary<PositionInputArguments>
        {
            { InputAttributesSet.WalkFree, new KeyDownKeyboardInputControl(KeyCode.W) }
        });
    }

    public bool GetIsControl<T>(InputAttribute attribute, T arguments) where T : InputArguments
    {
        return _inputDictionary.GetIsControl(attribute, arguments);
    }
}
