using ProjectEuler.Utils;
using System.Collections.Generic;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem27 : IProblem
    {
        private long Polynomial(long n, long a, long b)
        {
            return (n * n) + (a * n) + b;
        }

        public string Run()
        {
            var primes = Prime.Sieve.UpTo<HashSet<long>>(1000000L);
            long longest = 0, maxA = 0, maxB = 0;
            for (long b = 2; b <= 1000; b++)
            {
                if (primes.Contains(b))
                {
                    for (long a = -1000; a <= 1000; a++)
                    {
                        long n = 0;
                        while (primes.Contains(Polynomial(n, a, b)))
                        {
                            n++;
                        }
                        if (n > longest)
                        {
                            maxA = a;
                            maxB = b;
                            longest = n;
                        }
                    }
                }
            }
            return (maxA * maxB).ToString();
        }
    }
}
