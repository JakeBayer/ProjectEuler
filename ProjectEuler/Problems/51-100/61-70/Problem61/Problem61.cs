using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem61 : IProblem
    {
        private static GeometricNumber Heptagonal = new GeometricNumber(7);
        private const long TEN_THOUSAND = 10000L;
        private readonly Dictionary<int, HashSet<long>> baseToNumbers = new Dictionary<int, HashSet<long>>
        {
            [3] = new Triangular().GenerateUpTo(TEN_THOUSAND),
            [4] = new Squares().GenerateUpTo(TEN_THOUSAND),
            [5] = new Pentagonal().GenerateUpTo(TEN_THOUSAND),
            [6] = new Hexagonal().GenerateUpTo(TEN_THOUSAND),
            //[7] = 
        };

        public string Run()
        {
            throw new NotImplementedException();
        }
    }
}
