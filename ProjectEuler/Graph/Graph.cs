using System.Collections.Generic;

namespace ProjectEuler.Graph
{
    public class Graph<T>
    {
        public Graph(IDictionary<T, HashSet<T>> nodes)
        {
            Neighbors = nodes;
        }

        public IDictionary<T, HashSet<T>> Neighbors { get; }
    }
}
