namespace Components.EventHandler
{
    /// <summary>
    /// Отнаследованный от данного интерфейса класс становится подписчиком 
    /// для оповещателей событий с типом аргументов A
    /// </summary>
    /// <typeparam name="A">Тип аргумента событий. Идентифицирует события </typeparam>
    public interface IEventListener<A> where A : IEventArguments
    {
        void HandleEvent(A arguments, object sender);
    }
}

