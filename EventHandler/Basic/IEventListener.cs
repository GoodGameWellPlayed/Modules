public interface IEventListener<A> where A : EventArguments
{
    void HandleEvent(A arguments, object sender);
}
