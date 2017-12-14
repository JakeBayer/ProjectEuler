using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem78 : IProblem
    {
        private const int ONE_THOUSAND = 8000;
        private const int ONE_MILLION = 1000000;
        public string Run()
        {
            var part = new Partition(Enumerable.Range(1, ONE_THOUSAND));

            BigInteger ways = 1;
            var curr = 1;
            while (ways % ONE_MILLION != 0)
            {
                curr++;
                ways = part.Count(curr);
            }
            return curr.ToString();
        }
    }
}
