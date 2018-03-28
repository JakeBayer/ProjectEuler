namespace ProjectEuler.Graph
{
    public interface INode<out T>
    {
        T Value { get; }
    }
}
