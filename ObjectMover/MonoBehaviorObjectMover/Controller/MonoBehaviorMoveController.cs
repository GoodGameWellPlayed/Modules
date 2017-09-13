using UnityEngine;

public abstract class MonoBehaviorMoveController : MonoBehaviour, IMoveController
{
    public abstract IControlArguments GetArguments();
}
