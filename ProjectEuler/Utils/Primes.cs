using System;
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
            for (long i = 3; i < (long)Math.Sqrt(max + 1); i += 2)
            {
                if (!compositness[i])
                {
                    for (long j = 2; j <= (max + 1) / i - 1; j++)
                    {
                        compositness[i * j] = true;
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
