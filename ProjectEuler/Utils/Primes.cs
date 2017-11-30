﻿using System;
using System.Collections.Generic;

namespace ProjectEuler.Utils
{
    public static class Primes
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
                    for (long j = i*2; j <= max; j += i)
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

        public class InitializedPrimes
        {
            private static List<long> _primes;
            public InitializedPrimes(long max)
            {
                _primes = Primes.UpTo<List<long>>(max);
            }

            public bool IsPrime(long n)
            {
                var sqrt = Math.Sqrt(n);
                if (_primes[_primes.Count - 1] < (long)sqrt)
                {
                    _primes = Primes.UpTo<List<long>>((long)sqrt * 2);
                }
                return !(n < 2) && (n == 2 || IsPrime(n, 1, sqrt));
            }

            private bool IsPrime(long n, int idx, double sqrt)
            {
                long d = _primes[idx];
                return !(n % d == 0) && (d > sqrt || IsPrime(n, ++idx, sqrt));
            }
        }

        public static InitializedPrimes Initialize(long upTo)
        {
            return new InitializedPrimes(upTo);
        }

        public static bool IsPrime(long n)
        {
            return !(n < 2) && (n == 2 || IsPrime(n, 3, Math.Sqrt(n)));
        }

        private static bool IsPrime(long n, long d, double sqrt)
        {
            return !(n % d == 0) && (d > sqrt || IsPrime(n, d + 2, sqrt));
        }
    }
}
