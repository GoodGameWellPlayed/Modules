using UnityEngine;

public interface IInputDevicePositioned
{
    bool IsCursorMoved(out Vector3 cursorPosition);
}

public interface IInputDevicePositioned<I>
{
    bool IsCursorMoved(I cursorIdentifier, out Vector3 cursorPosition);
}

public class Iii<A>
{

}

public class Iiii : Iii<object>
{

}

public class Ooo
{
    public void i<L, A>(A obj) where L : Iii<A>
    {

    }

    void start()
    {
        Iiii ii = 
    }
}

