public interface IInputManager
{
    bool GetIsControl<A>(InputAttribute attribute, A arguments) where A : class, IInputArguments;

    bool GetIsControl(InputAttribute attribute);
}
