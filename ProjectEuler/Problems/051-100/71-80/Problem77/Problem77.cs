using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Numerics;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem77 : IProblem
    {
        private const int ONE_THOUSAND = 1000;
        public string Run()
        {
            var primes = Prime.Sieve.UpTo<List<int>>(ONE_THOUSAND);
            var part = new Partition(primes);

            BigInteger ways = 0;
            var curr = 1;
            while (ways < 5000)
            {
                curr++;
                ways = part.Count(curr);
            }
            return curr.ToString();
        }
    }
}
