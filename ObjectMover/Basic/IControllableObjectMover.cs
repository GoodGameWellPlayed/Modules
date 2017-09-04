public interface IControllableObjectMover<A> where A : ControlArguments
{
    bool Move(A arguments);
}
