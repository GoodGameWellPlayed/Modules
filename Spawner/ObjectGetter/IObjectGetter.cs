public interface IObjectGetter<I, T>
{
    T GetObject(I objectIdentity);
}

public interface IRandomObjectGetter<T>
{
    T GetRandomObject();
}

