namespace Components.EventHandler
{
    /// <summary>
    /// Менеджер событий. Лучше делать один Singleton объект с публичным доступом.
    /// Для корректной работы менеджера подписчик типа IEventListener
    /// должен подписаться, используя метод SubscribeListener, и, при необходимости,
    /// отписаться, используя UnSubscribeListener.
    /// Notify используется для оповещении подписчиков типа IEventListener<A> о 
    /// происшедшем событии
    /// </summary>
    public interface IEventManager
    {
        void Notify<A>(A arguments, object sender) where A : IEventArguments;

        void SubscribeListener<A>(IEventListener<A> listener) where A : IEventArguments;

        void UnSubscribeListener<A>(IEventListener<A> listener) where A : IEventArguments;
    }
}

