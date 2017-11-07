using UnityEngine;

namespace Components.Common
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(T).Name;
                        _instance = newGameObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this as T;
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }
    }
}

