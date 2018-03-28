using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Linq;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem549 : IProblem
    {
        //private Dictionary<long, Prime.Factorization> _factorizations;
        //public Problem549()
        //{
        //    //_factorizations = Prime.Factorization.Of(Range(2L, 100 - 1));
        //    _factorizations = Prime.Factorization.Of(Range(2L, 100000000 - 1));
        //}
        private IEnumerable<long> Range(long start, long count)
        {
            var end = start + count;
            for (long current = start; current < end; current++)
            {
                yield return current;
            }
        }

        private long GetSmallestFactorialWithThisManyOfThisPrime(long prime, int exp)
        {
            if (prime > exp) return prime * exp;
            var numPrimes = 0;
            var current = 0L;
            while (numPrimes < exp)
            {
                current += prime;
                var val = current;
                while (val % prime == 0)
                {
                    val /= prime;
                    numPrimes++;
                }
            }
            return current;
        }

        public string Run()
        {
            var s_n = Range(2L, 100000000 - 1).Select(n => Prime.Factorization.Of(n).Max(primeExpPair => GetSmallestFactorialWithThisManyOfThisPrime(primeExpPair.Key, primeExpPair.Value))).ToArray();
            //var s_n = _factorizations.Select(f => f.Value.Max(primeExpPair => GetSmallestFactorialWithThisManyOfThisPrime(primeExpPair.Key, primeExpPair.Value))).ToArray();
            return s_n.Sum().ToString();
        }
    }
}
