public interface IControllableObjectMover<A> where A : IControlArguments
{
    bool Move(A arguments);
}
