namespace ProjectEuler.Graph
{
    public abstract class NodeBase<T> : INode<T>
    {
        private readonly T _value;

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
