using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    Debug.LogError("Instance of " + _instance.GetType().Name + " is not present on a scene");
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
