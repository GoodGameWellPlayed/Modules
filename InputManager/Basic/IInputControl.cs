public interface IInputControl<in T> where T : InputArguments
{
    bool GetIsControl(T arguments = null);
}
