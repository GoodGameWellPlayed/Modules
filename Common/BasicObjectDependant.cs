using UnityEngine;

public abstract class BasicObjectDependant<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _basicObject;

    protected T BasicObject
    {
        get
        {
            if (_basicObject == null)
            {
                _basicObject = GetComponent<T>();
            }
            if (_basicObject == null)
            {
                Debug.LogError("You need " + typeof(T).ToString() + " component for this object");
            }
            return _basicObject;
        }
    }
}
