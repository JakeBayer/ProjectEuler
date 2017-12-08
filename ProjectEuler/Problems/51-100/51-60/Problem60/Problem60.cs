using ProjectEuler.Graph;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem60 : IProblem
    {
        private const long UpTo = 10000;
        private Prime _primeChecker = new Prime(UpTo);
        private readonly SortedSet<long> _primes = Prime.Sieve.UpTo<SortedSet<long>>(UpTo);
        private Graph<long> _primeGraph = new Graph<long>(new Dictionary<long, HashSet<long>>());


        private void BuildPrimeAdjacencyGraph()
        {
            foreach (var prime1 in _primes)
            {
                foreach (var prime2 in _primes.Where(p => p > prime1))
                {
                    CheckAndAddPair(prime1, prime2);
                }
            }
        }

        private void CheckAndAddPair(long prime1, long prime2)
        {
            var p1_str = prime1.ToString();
            var p2_str = prime2.ToString();
            if (_primeChecker.IsPrime(long.Parse(p1_str + p2_str)) && _primeChecker.IsPrime(long.Parse(p2_str + p1_str)))
            {
                if (!_primeGraph.Neighbors.ContainsKey(prime1))
                {
                    _primeGraph.Neighbors.Add(prime1, new HashSet<long>());
                }
                if (!_primeGraph.Neighbors.ContainsKey(prime2))
                {
                    _primeGraph.Neighbors.Add(prime2, new HashSet<long>());
                }
                if (!_primeGraph.Neighbors[prime1].Contains(prime2))
                {
                    _primeGraph.Neighbors[prime1].Add(prime2);
                }
                if (!_primeGraph.Neighbors[prime2].Contains(prime2))
                {
                    _primeGraph.Neighbors[prime2].Add(prime1);
                }
            }
        }

        private List<HashSet<long>> _cliques = new List<HashSet<long>>();

        private void BronKerbosch2(HashSet<long> R, HashSet<long> P, HashSet<long> X)
        {
            if (!P.Any() && !X.Any())
            {
                _cliques.Add(R);
                return;
            }
            var PUX = new HashSet<long>(P);
            PUX.UnionWith(X);
            var u = PUX.OrderByDescending(x => _primeGraph.Neighbors[x].Count).First();
            var PExceptNeighbors = new HashSet<long>(P);
            PExceptNeighbors.ExceptWith(_primeGraph.Neighbors[u]);
            foreach (var v in PExceptNeighbors)
            {
                BronKerbosch2(new HashSet<long>(R.Union(new[] { v })), new HashSet<long>(P.Intersect(_primeGraph.Neighbors[v])), new HashSet<long>(X.Intersect(_primeGraph.Neighbors[v])));
                var vAsEnum = new[] { v };
                P.ExceptWith(vAsEnum);
                X.UnionWith(vAsEnum);
            }
        }

        public string Run()
        {
            BuildPrimeAdjacencyGraph();
            BronKerbosch2(new HashSet<long>(), new HashSet<long>(_primeGraph.Neighbors.Keys), new HashSet<long>());
            var cliques = _cliques.Where(c => c.Count() >= 5);
            return cliques.First().Sum().ToString();
        }
    }
}
