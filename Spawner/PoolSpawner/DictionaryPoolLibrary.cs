using System;
using System.Collections.Generic;

namespace Components.Spawner.Pool
{
    /// <summary>
    /// Содержит связи между объектами и пулами по принципу словаря
    /// </summary>
    public class DictionaryPoolLibrary : IObjectPoolLibrary
    {
        private Dictionary<object, object> _poolsDictionary;

        public DictionaryPoolLibrary()
        {
            _poolsDictionary = new Dictionary<object, object>(20);
        }

        public void AddDependency<T>(T poolableObject, IPool<T> pool)
        {
            if (!_poolsDictionary.ContainsKey(poolableObject))
            {
                _poolsDictionary.Add(poolableObject, pool);
            }
        }

        public IPool<T> GetPool<T>(T poolableObject)
        {
            if (!_poolsDictionary.ContainsKey(poolableObject))
            {
                return null;
            }
            return _poolsDictionary[poolableObject] as IPool<T>;
        }

        public void RemoveDependency<T>(T poolableObject)
        {
            if (_poolsDictionary.ContainsKey(poolableObject))
            {
                _poolsDictionary.Remove(poolableObject);
            }
        }

        public void Dispose()
        {
            foreach (object pool in _poolsDictionary.Values)
            {
                (pool as IDisposable).Dispose();
            }
            _poolsDictionary.Clear();
        }
    }
}

