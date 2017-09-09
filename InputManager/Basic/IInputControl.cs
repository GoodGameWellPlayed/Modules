public interface IInputControl<A> where A : InputArguments
{
    bool GetIsControl(A arguments = null);
}
