public interface IControllableObjectMover<A> : IObjectMover
    where A : IControlArguments
{
    bool Move(A arguments);
}
