using System.Collections.Generic;

namespace ProjectEuler.Graph
{
    class Graph<T>
    {
        private readonly IDictionary<T, HashSet<T>> _neighbors;

        public Graph(IDictionary<T, HashSet<T>> nodes)
        {
            _neighbors = nodes;
        }

        public IDictionary<T, HashSet<T>> Neighbors => _neighbors;
    }
}
