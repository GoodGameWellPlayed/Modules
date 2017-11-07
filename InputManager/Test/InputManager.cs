using UnityEngine;

public class InputManager : IInputManager
{
    public static InputManager Instance = new InputManager();

    private InputDictionary _inputDictionary;

    private EmptyInputArguments _emptyInputArguments = new EmptyInputArguments();

    private static KeyboardInputDevice Keyboard = new KeyboardInputDevice();
    private static MouseInputDevice Mouse = new MouseInputDevice();

    private InputManager()
    {
        _inputDictionary = new InputDictionary()
        {
            { InputAttributesSet.WalkDown,
                new ActionInputControl((arguments) => { return Keyboard.IsHolding(KeyCode.S); }) },
            { InputAttributesSet.WalkLeft,
                new ActionInputControl((arguments) => { return Keyboard.IsHolding(KeyCode.A); }) },
            { InputAttributesSet.WalkRight,
                new ActionInputControl((arguments) => { return Keyboard.IsHolding(KeyCode.D); }) },
            { InputAttributesSet.WalkUp,
                new ActionInputControl((arguments) => { return Keyboard.IsHolding(KeyCode.W); }) },

            { InputAttributesSet.CursorMove,
                new ActionInputControl((arguments) => 
                {
                    Mouse.GetCursorPosition(arguments as IPositionInputArguments);
                    return Mouse.IsCursorMoving();
                })
            },
            { InputAttributesSet.CursorClick,
                new ActionInputControl((arguments) => { return Mouse.IsPressed(MouseButtons.Left); }) },
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

