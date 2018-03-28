using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem87 : IProblem
    {
        private const long FIFTY_MILLION = 50000000;
        public string Run()
        {
            List<long> squares = new List<long>(), cubes = new List<long>(), quads = new List<long>();
            HashSet<long> values = new HashSet<long>();
            var primes = Prime.Sieve.UpTo<List<long>>((long)Math.Sqrt(FIFTY_MILLION) + 1);
            squares = NthPowersOfUpTo(2, primes, FIFTY_MILLION);
            cubes = NthPowersOfUpTo(3, primes, FIFTY_MILLION);
            quads = NthPowersOfUpTo(4, primes, FIFTY_MILLION);
            
            foreach(var square in squares)
            {
                foreach (var cube in cubes)
                {
                    foreach (var quad in quads)
                    {
                        if (square + cube + quad < FIFTY_MILLION)
                        {
                            values.Add(square + cube + quad);
                        }
                    }
                }
            }
            return values.Count.ToString();
        }

        private List<long> NthPowersOfUpTo(long n, IEnumerable<long> values, long upTo)
        {
            var nthPowers = new List<long>();
            foreach (var curr in values)
            {
                var pow = 0;
                var last = 1L;
                while (pow < n)
                {
                    last *= curr;
                    pow++;
                }
                nthPowers.Add(last);
                if (last > upTo) return nthPowers;
            }
            return nthPowers;
        }
    }
}
