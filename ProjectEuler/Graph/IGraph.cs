using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Graph
{
    public interface IGraph<T>
    {
        IDictionary<T, INode<T>> Nodes { get; }
    }
}
