using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Graph
{
    public class Node<T> : NodeBase<T>
    {
        private LinkedList<Node<T>> _neighbors;
        public Node(T value) : base(value)
        {
            _neighbors = new LinkedList<Node<T>>();
        }

        public Node(Node<T> node) : base(node.Value)
        {
            _neighbors = new LinkedList<Node<T>>(node.Neighbors);
        }

        public LinkedList<Node<T>> Neighbors => _neighbors;
    }
}
