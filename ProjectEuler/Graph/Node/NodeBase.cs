using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Graph
{
    public abstract class NodeBase<T> : INode<T>
    {
        private T _value;

        public NodeBase(T value)
        {
            _value = value;
        }

        public NodeBase(NodeBase<T> node)
        {
            _value = node.Value;
        }

        public T Value => _value;
    }
}
