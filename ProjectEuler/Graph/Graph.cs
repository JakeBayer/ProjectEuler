using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Graph
{
    class Graph<T>
    {
        private IDictionary<T, HashSet<T>> _neighbors;

        public Graph(IDictionary<T, HashSet<T>> nodes)
        {
            _neighbors = nodes;
        }

        public IDictionary<T, HashSet<T>> Neighbors => _neighbors;
    }
}
