﻿using UnityEngine;

namespace Components.Spawner.Pool.PrefabPool
{
    /// <summary>
    /// Стандартная библиотека генераторов объектов Unity
    /// </summary>
    public static class ObjectInstantiatorFactory
    {
        public static IObjectInstantiator<T> GetObjectInstantiator<T>(T obj)
        {
            if (obj is GameObject)
            {
                return new GameObjectInstantiator() as IObjectInstantiator<T>;
            }
            if (obj is Component)
            {
                return new ComponentInstantiator<T>() as IObjectInstantiator<T>;
            }
            return null;
        }
    }
}

