using UnityEngine;

public abstract class ObjectDependantControllableObjectMover<A, T> : ObjectDependantObjectMover<T>, 
    IControllableObjectMover<A> where A : IControlArguments where T : MonoBehaviour
{
    protected abstract IMoveController Controller { get; }

    public abstract bool Move(A arguments);

    public override void Move()
    {
        IControlArguments arguments = Controller.GetArguments();

        if (!(arguments is A) && (arguments != null))
        {
            Debug.LogError("Controller should return the other type of arguments");
        }

        if (!Move((A)arguments))
        {
            Stay();
        }
    }

    protected virtual void Stay() { }
}
