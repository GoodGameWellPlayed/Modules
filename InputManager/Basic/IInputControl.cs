public interface IInputControl<A> where A : IInputArguments
{
    //TODO для разных типов InputArguments
    bool GetIsControl(A arguments);
}
