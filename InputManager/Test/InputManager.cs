using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Dictionary<Type, object> _commonDictionary;

    private static KeyboardInputDevice Keyboard = new KeyboardInputDevice();
    private static MouseInputDevice Mouse = new MouseInputDevice();

    private static IInputControl<T> CreateInputControl<T>(InputDeviceType inputDeviceType, object buttonIdentifier, 
        InputType inputType) where T : class, IInputArguments
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
                            (KeyCode)(buttonIdentifier), ControlType.Press) as IInputControl<T>;
                    }
                    case InputType.Release:
                    {
                        return new ClickButtonDeviceInputControl<KeyboardInputDevice, KeyCode>(Keyboard,
                            (KeyCode)(buttonIdentifier), ControlType.Release) as IInputControl<T>;
                    }
                    case InputType.Hold:
                    {
                        return new HoldButtonDeviceInputControl<KeyboardInputDevice, KeyCode>(Keyboard,
                            (KeyCode)(buttonIdentifier)) as IInputControl<T>;
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
                            (MouseButtons)(buttonIdentifier), ControlType.Press) as IInputControl<T>;
                    }
                    case InputType.Release:
                    {
                        return new ClickButtonDeviceInputControl<MouseInputDevice, MouseButtons>(Mouse,
                            (MouseButtons)(buttonIdentifier), ControlType.Release) as IInputControl<T>;
                    }
                    case InputType.Hold:
                    {
                        return new HoldButtonDeviceInputControl<MouseInputDevice, MouseButtons>(Mouse,
                            (MouseButtons)(buttonIdentifier)) as IInputControl<T>;
                    }
                    case InputType.Move:
                    {
                        return new MoveCursorDeviceInputControl<MouseInputDevice>(Mouse) as IInputControl<T>;
                    }
                }
                break;
            }
        }
        return null;
    }

    private void Start()
    {
        _commonDictionary = new Dictionary<Type, object>();

        //filling dictionary without arguments
        _commonDictionary.Add(typeof(EmptyInputArguments), new InputDictionary<EmptyInputArguments>
        {
            { InputAttributesSet.WalkDown,
                CreateInputControl<EmptyInputArguments>(InputDeviceType.Keyboard, KeyCode.S, InputType.Hold) },
            { InputAttributesSet.WalkLeft,
                CreateInputControl<EmptyInputArguments>(InputDeviceType.Keyboard, KeyCode.A, InputType.Hold) },
            { InputAttributesSet.WalkRight,
                CreateInputControl<EmptyInputArguments>(InputDeviceType.Keyboard, KeyCode.D, InputType.Hold) },
            { InputAttributesSet.WalkUp,
                CreateInputControl<EmptyInputArguments>(InputDeviceType.Keyboard, KeyCode.W, InputType.Hold) },
        });

        //filling dictionary with Duration argument
        _commonDictionary.Add(typeof(PositionInputArguments), new InputDictionary<PositionInputArguments>
        {
            { InputAttributesSet.CursorMove,
                CreateInputControl<PositionInputArguments>(InputDeviceType.Mouse, MouseButtons.Left, InputType.Press) },
            { InputAttributesSet.CursorClick,
                CreateInputControl<PositionInputArguments>(InputDeviceType.Mouse, MouseButtons.Left, InputType.Move) }
        });
    }

    public bool GetIsControl<T>(InputAttribute attribute, T arguments = null) where T : class, IInputArguments
    {
        return (_commonDictionary[typeof(T)] as InputDictionary<T>).GetIsControl(attribute, arguments);
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

