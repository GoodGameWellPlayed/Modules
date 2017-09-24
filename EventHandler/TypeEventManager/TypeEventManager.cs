using System;
using System.Collections.Generic;

public class TypeEventManager : Singleton<TypeEventManager>, IEventManager
{
    private Dictionary<Type, List<object>> _listeners;
    private Dictionary<Type, List<object>> Listeners
    {
        get
        {
            if (_listeners == null)
            {
                _listeners = new Dictionary<Type, List<object>>();
            }
            return _listeners;
        }
    }

    public void Notify<A>(A arguments, object sender) where A : EventArguments
    {
        Type aType = typeof(A);

        if (Listeners.ContainsKey(aType))
        {
            for (int i = 0; i < Listeners[aType].Count; i++)
            {
                (Listeners[aType][i] as IEventListener<A>).HandleEvent(arguments, sender);
            }
        }
    }

    public void SubscribeListener<A>(IEventListener<A> listener) where A : EventArguments
    {
        Type aType = typeof(A);

        if (!Listeners.ContainsKey(aType))
        {
            Listeners.Add(aType, new List<object>(10));
        }
        Listeners[aType].Add(listener);
    }

    public void UnSubscribeListener<A>(IEventListener<A> listener) where A : EventArguments
    {
        Type aType = typeof(A);

        if (!Listeners.ContainsKey(aType))
        {
            return;
        }
        //todo not an easy operation
        Listeners[aType].Remove(listener);
        if (Listeners[aType].Count == 0)
        {
            Listeners.Remove(aType);
        }
    }
}
