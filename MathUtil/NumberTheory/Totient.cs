using System;
using MathUtil.NumberTheory.Extensions;

namespace MathUtil.NumberTheory
{
    public class Totient
    {
        public Totient() { }
        public Totient(long max)
        {
            Initialize(max);
        }

        public Totient Initialize(long max)
        {
            Prime.Initialize(max);
            return this;
        }

        public long phi(long n)
        {
            var sqrt = Math.Sqrt(n);
            if (Prime.Primes.Count == 0 || Prime.Primes[Prime.Primes.Count - 1] < (long)sqrt)
            {
                Prime.Initialize((long)sqrt * 2);
            }
            return phi_helper(n);
        }

        private long phi_helper(long n)
        {
            // Base case
            if (n < 2)
                return 0;

            // Lehmer's conjecture
            if (n.IsPrime())
                return n - 1;

            // Even number?
            if ((n & 1) == 0)
            {
                long m = n >> 1;
                return (m & 1) == 0 ? phi(m) << 1 : phi(m);
            }

            // For all primes ...
            foreach (var p in Prime.Primes)
            {
                if (n % p != 0) continue;

                // phi is multiplicative
                long o = n / p;
                long d = p.GCD(o);
                return d == 1 ? phi(p) * phi(o) : phi(p) * phi(o) * d / phi(d);
            }
            throw new Exception("This should never be reached. You broke math.");
        }

        public static long[] UpTo(long max)
        {
            var phis = new long[max + 1];
            for (long j = 0; j <= max; j++)
            {
                phis[j] = j;
            }

            for (long j = 2; j <= max; j++)
            {
                if (phis[j] == j)
                {
                    phis[j]--;
                    for (long i = 2 * j; i <= max; i += j)
                    {
                        phis[i] = (phis[i] / j) * (j - 1);
                    }
                }
            }
            return phis;
        }
    }
}
