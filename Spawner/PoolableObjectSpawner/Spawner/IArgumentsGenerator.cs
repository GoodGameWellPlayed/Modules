using System.Collections.Generic;

public class PoolSpawnInfo<A, I> where A : IPoolArguments
{
    public A Arguments { get; set; }
    public I PoolIdentity { get; set; }
}

public interface IArgumentsGenerator<A, I> where A : IPoolArguments
{
    IEnumerable<PoolSpawnInfo<A, I>> GetPoolableArguments();
}
