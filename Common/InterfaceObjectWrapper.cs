using System;
using UnityEngine;

namespace Components.Common
{
    /// <summary>
    /// Обертка для нахождения UnityEditor'ом объектов по интерфейсу
    /// </summary>
    [Serializable]
    public abstract class InterfaceObjectWrapper<T>
    {
        [SerializeField] private Component _interfaceObject;

        private T _resultedObject;

        public T Object
        {
            get
            {
                if (_resultedObject == null)
                {
                    _resultedObject = _interfaceObject.GetComponent<T>();
                }
                return _resultedObject;
            }
        }
    }
}

