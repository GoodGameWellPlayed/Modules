public interface IInputControl
{
    bool GetIsControl<A>(A arguments) where A : IInputArguments;
}
