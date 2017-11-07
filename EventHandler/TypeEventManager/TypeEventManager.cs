using System;
using System.Collections.Generic;

namespace Components.EventHandler
{
    /// <summary>
    /// EventManager, записывающий подписчика в структуру данных по типу аргумента,
    /// который его событие использует
    /// </summary>
    public class TypeEventManager : IEventManager
    {
        public static TypeEventManager Instance = new TypeEventManager();

        private Dictionary<Type, List<object>> _listeners;

        private TypeEventManager()
        {
            _listeners = new Dictionary<Type, List<object>>();
        }

        public void Notify<A>(A arguments, object sender) where A : IEventArguments
        {
            Type aType = typeof(A);

            if (_listeners.ContainsKey(aType))
            {
                for (int i = 0; i < _listeners[aType].Count; i++)
                {
                    (_listeners[aType][i] as IEventListener<A>).HandleEvent(arguments, sender);
                }
            }
        }

        public void SubscribeListener<A>(IEventListener<A> listener) where A : IEventArguments
        {
            Type aType = typeof(A);

            if (!_listeners.ContainsKey(aType))
            {
                _listeners.Add(aType, new List<object>(10));
            }
            _listeners[aType].Add(listener);
        }

        public void UnSubscribeListener<A>(IEventListener<A> listener) where A : IEventArguments
        {
            Type aType = typeof(A);

            if (!_listeners.ContainsKey(aType))
            {
                return;
            }
            //todo not an easy operation
            _listeners[aType].Remove(listener);
            if (_listeners[aType].Count == 0)
            {
                _listeners.Remove(aType);
            }
        }
    }
}

