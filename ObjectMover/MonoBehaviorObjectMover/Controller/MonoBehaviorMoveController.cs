using UnityEngine;

public abstract class MonoBehaviorMoveController : MonoBehaviour, IMoveController
{
    public abstract ControlArguments GetArguments();
}
