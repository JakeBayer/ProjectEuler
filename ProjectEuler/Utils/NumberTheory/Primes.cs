using System;
using System.Collections.Generic;

namespace ProjectEuler.Utils
{
    public class Prime
    {
        private List<long> _primes = new List<long>();

        public Prime() { }

        public Prime(long max)
        {
            Initialize(max);
        }

        public Prime Initialize(long max)
        {
            _primes = Sieve.UpTo<List<long>>(max);
            return this;
        }

        public bool IsPrime(long n)
        {
            var sqrt = Math.Sqrt(n);
            if (_primes.Count == 0 || _primes[_primes.Count - 1] < (long)sqrt)
            {
                _primes = Sieve.UpTo<List<long>>((long)sqrt * 2);
            }
            return !(n < 2) && (n == 2 || IsPrime(n, 1, sqrt));
        }

        private bool IsPrime(long n, int idx, double sqrt)
        {
            long d = _primes[idx];
            return !(n % d == 0) && (d > sqrt || IsPrime(n, ++idx, sqrt));
        }

        public static bool ExhaustiveIsPrime(long n)
        {
            return !(n < 2) && (n == 2 || ExhaustiveIsPrime(n, 3, Math.Sqrt(n)));
        }

        private static bool ExhaustiveIsPrime(long n, long d, double sqrt)
        {
            return !(n % d == 0) && (d > sqrt || ExhaustiveIsPrime(n, d + 2, sqrt));
        }

        public List<long> Primes => _primes;

        public class Sieve
        {
            private static bool[] Compositness(long max)
            {
                var t = max + 1;
                var compositness = new bool[max + 1];
                compositness[0] = true;
                compositness[1] = true;

                for (long i = 4; i < max + 1; i += 2)
                {
                    compositness[i] = true;
                }
                for (long i = 3; i < (long)Math.Sqrt(max) + 1; i += 2)
                {
                    if (!compositness[i])
                    {
                        for (long j = i * 2; j <= max; j += i)
                        {
                            compositness[j] = true;
                        }
                    }
                }
                return compositness;
            }

            public static T UpTo<T>(long max) where T : ICollection<long>, new()
            {
                var compositness = Compositness(max);
                var primes = new T { 2L };
                for (long i = 3L; i < compositness.LongLength; i += 2)
                {
                    if (!compositness[i]) primes.Add(i);
                }
                return primes;
            }

            public static T UpTo<T>(int max) where T : ICollection<int>, new()
            {
                var compositness = Compositness(max);
                var primes = new T { 2 };
                for (int i = 3; i < compositness.Length; i += 2)
                {
                    if (!compositness[i]) primes.Add(i);
                }
                return primes;
            }
        }
    }
}
