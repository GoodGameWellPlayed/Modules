using System.Collections.Generic;

public interface IArgumentsGenerator
{
    IEnumerable<PoolableObjectArguments> GetPoolableArguments();
}
