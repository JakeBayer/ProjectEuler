using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<long> ToLongList(long max)
        {
            var compositness = Compositness(max);
            var Primes = new List<long> { 2L };
            for (long i = 3L; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }

        public static List<int> ToIntList(int max)
        {
            var compositness = Compositness(max);
            var Primes = new List<int> { 2 };
            for (int i = 3; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }

        public static HashSet<long> ToLongHash(long max)
        {
            var compositness = Compositness(max);
            var Primes = new HashSet<long> { 2L };
            for (long i = 3L; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }

        public static HashSet<int> ToIntHash(int max)
        {
            var compositness = Compositness(max);
            var Primes = new HashSet<int> { 2 };
            for (int i = 3; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }

        public static SortedSet<long> ToLongSortedSet(long max)
        {
            var compositness = Compositness(max);
            var Primes = new SortedSet<long> { 2L };
            for (long i = 3L; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }

        public static SortedSet<int> ToIntSortedSet(int max)
        {
            var compositness = Compositness(max);
            var Primes = new SortedSet<int> { 2 };
            for (int i = 3; i < max; i += 2)
            {
                if (!compositness[i]) Primes.Add(i);
            }
            return Primes;
        }
    }
}
