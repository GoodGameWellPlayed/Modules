using UnityEngine;

public abstract class ObjectDependantObjectMover<T> : BasicObjectDependant<T>, IObjectMover
    where T : MonoBehaviour
{
    public abstract void Move();

    void Update ()
    {
        Move();
    }
}
