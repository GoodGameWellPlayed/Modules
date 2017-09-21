public interface IInputControl
{
    //TODO no <A>
    bool GetIsControl<A>(A arguments) where A : class, IInputArguments;
}
