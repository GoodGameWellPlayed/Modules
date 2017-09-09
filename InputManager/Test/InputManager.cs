using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private InputDictionary _inputDictionary;

    private void Start()
    {
        _inputDictionary = new InputDictionary();

        _inputDictionary.Add(InputAttributesSet.WalkDown, new KeyboardInputControl(KeyCode.DownArrow));
        _inputDictionary.Add(InputAttributesSet.WalkLeft, new KeyboardInputControl(KeyCode.LeftArrow));
        _inputDictionary.Add(InputAttributesSet.WalkRight, new KeyboardInputControl(KeyCode.RightArrow));
        _inputDictionary.Add(InputAttributesSet.WalkUp, new KeyboardInputControl(KeyCode.UpArrow));
    }

    public bool GetIsControl(InputAttribute attribute, InputArguments arguments)
    {
        return _inputDictionary.GetIsControl(attribute, arguments);
    }
}
