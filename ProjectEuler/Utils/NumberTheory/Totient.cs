using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Totient
    {
        private Prime _prime;
        private bool _initialized = false;

        public Totient()
        {
            _prime = new Prime();
        }
        public Totient(long max)
        {
            Initialize(max);
        }

        public Totient Initialize(long max)
        {
            _prime = new Prime(max);
            _initialized = true;
            return this;
        }

        public long phi(long n)
        {
            var sqrt = Math.Sqrt(n);
            if (_prime.Primes.Count == 0 || _prime.Primes[_prime.Primes.Count - 1] < (long)sqrt)
            {
                _prime.Initialize((long)sqrt * 2);
            }
            return phi_helper(n);
        }

        private long phi_helper(long n)
        {
            // Base case
            if (n < 2)
                return 0;

            // Lehmer's conjecture
            if (_prime.IsPrime(n))
                return n - 1;

            // Even number?
            if ((n & 1) == 0)
            {
                long m = n >> 1;
                return (m & 1) == 0 ? phi(m) << 1 : phi(m);
            }

            // For all primes ...
            foreach (var p in _prime.Primes)
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
