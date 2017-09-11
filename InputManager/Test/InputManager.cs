using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>, IInputManager
{
    private InputDictionary _inputDictionary;

    private EmptyInputArguments _emptyInputArguments = new EmptyInputArguments();

    private static KeyboardInputDevice Keyboard = new KeyboardInputDevice();
    private static MouseInputDevice Mouse = new MouseInputDevice();

    private static IInputControl CreateInputControl(InputDeviceType inputDeviceType, object buttonIdentifier, 
        InputType inputType)
    {
        switch (inputDeviceType)
        {
            case InputDeviceType.Keyboard:
            {
                switch (inputType)
                {
                    case InputType.Press:
                    {
                        return new ClickButtonDeviceInputControl<KeyboardInputDevice, KeyCode>(Keyboard,
                            (KeyCode)(buttonIdentifier), ControlType.Press) as IInputControl;
                    }
                    case InputType.Release:
                    {
                        return new ClickButtonDeviceInputControl<KeyboardInputDevice, KeyCode>(Keyboard,
                            (KeyCode)(buttonIdentifier), ControlType.Release) as IInputControl;
                    }
                    case InputType.Hold:
                    {
                        return new HoldButtonDeviceInputControl<KeyboardInputDevice, KeyCode>(Keyboard,
                            (KeyCode)(buttonIdentifier)) as IInputControl;
                    }
                }
                break;
            }
            case InputDeviceType.Mouse:
            {
                switch (inputType)
                {
                    case InputType.Press:
                    {
                        return new ClickButtonDeviceInputControl<MouseInputDevice, MouseButtons>(Mouse,
                            (MouseButtons)(buttonIdentifier), ControlType.Press) as IInputControl;
                    }
                    case InputType.Release:
                    {
                        return new ClickButtonDeviceInputControl<MouseInputDevice, MouseButtons>(Mouse,
                            (MouseButtons)(buttonIdentifier), ControlType.Release) as IInputControl;
                    }
                    case InputType.Hold:
                    {
                        return new HoldButtonDeviceInputControl<MouseInputDevice, MouseButtons>(Mouse,
                            (MouseButtons)(buttonIdentifier)) as IInputControl;
                    }
                    case InputType.Move:
                    {
                        return new MoveCursorDeviceInputControl<MouseInputDevice>(Mouse) as IInputControl;
                    }
                }
                break;
            }
        }
        return null;
    }

    private void Start()
    {
        _inputDictionary = new InputDictionary()
        {
            { InputAttributesSet.WalkDown,
                CreateInputControl(InputDeviceType.Keyboard, KeyCode.S, InputType.Hold) },
            { InputAttributesSet.WalkLeft,
                CreateInputControl(InputDeviceType.Keyboard, KeyCode.A, InputType.Hold) },
            { InputAttributesSet.WalkRight,
                CreateInputControl(InputDeviceType.Keyboard, KeyCode.D, InputType.Hold) },
            { InputAttributesSet.WalkUp,
                CreateInputControl(InputDeviceType.Keyboard, KeyCode.W, InputType.Hold) },

            { InputAttributesSet.CursorMove,
                CreateInputControl(InputDeviceType.Mouse, MouseButtons.Left, InputType.Press) },
            { InputAttributesSet.CursorClick,
                CreateInputControl(InputDeviceType.Mouse, MouseButtons.Left, InputType.Move) }
        };
    }

    public bool GetIsControl<A>(InputAttribute attribute, A arguments) where A : class, IInputArguments
    {
        return _inputDictionary.GetIsControl(attribute, arguments);
    }

    public bool GetIsControl(InputAttribute attribute)
    {
        return _inputDictionary.GetIsControl(attribute, _emptyInputArguments);
    }
}

public enum InputDeviceType
{
    Keyboard,
    Mouse
}

public enum InputType
{
    Press,
    Release,
    Hold,
    Move
}

