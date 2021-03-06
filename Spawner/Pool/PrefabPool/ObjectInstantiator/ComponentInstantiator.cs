﻿using UnityEngine;

namespace Components.Spawner.Pool.PrefabPool
{
    /// <summary>
    /// Класс - создатель копий объектов типа GameObject при обращении через его компоненты
    /// </summary>
    public class ComponentInstantiator<T> : IObjectInstantiator<T>
    {
        public void DestroySpawnableObject(T spawnableObject)
        {
            GameObject.Destroy((spawnableObject as Component).gameObject);
        }

        public T InstantiateObject(T prefab)
        {
            return GameObject.Instantiate((prefab as Component).gameObject).GetComponent<T>();
        }

        public void SetObjectActive(T spawnableObject, bool isActive)
        {
            (spawnableObject as Component).gameObject.SetActive(isActive);
        }
    }
}

