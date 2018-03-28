using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem46 : IProblem
    {
        private const long MAX = 1000000;
        private readonly HashSet<long> primes = Prime.Sieve.UpTo<HashSet<long>>(MAX);
        private readonly List<long> squares = new List<long>(Enumerable.Range(0, (int)Math.Sqrt(MAX)).Select(i => (long)i * (long)i));
        public string Run()
        {
            long i = 7;
            bool found = false;
            while (!found)
            {
                i += 2;
                while (primes.Contains(i))
                {
                    i += 2;
                }
                int c = 1;
                found = true;
                while (i > 2 * squares[c])
                {
                    if (primes.Contains(i - 2 * squares[c]))
                    {
                        found = false;
                    }
                    c++;
                }
            }
            return i.ToString();
        }
    }
}
