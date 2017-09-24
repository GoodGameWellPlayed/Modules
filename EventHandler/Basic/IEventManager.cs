public interface IEventManager
{
    void Notify<A>(A arguments, object sender) where A : EventArguments;

    void SubscribeListener<A>(IEventListener<A> listener) where A : EventArguments;

    void UnSubscribeListener<A>(IEventListener<A> listener) where A : EventArguments;
}
