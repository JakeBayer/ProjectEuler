using System.Collections.Generic;

namespace ProjectEuler.Graph
{
    public interface IGraph<T>
    {
        IDictionary<T, INode<T>> Nodes { get; }
    }
}
