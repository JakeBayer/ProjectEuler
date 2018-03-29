using System;
using System.Collections.Generic;
using System.Linq;

namespace MathUtil.NumberTheory
{
    public static class Prime
    {
        private static List<long> s_primes = new List<long>();
        private static long s_max;
        private static object s_mutex = new object();

        public static void Initialize(long max)
        {
            s_primes = Sieve.UpTo<List<long>>(max);
            s_max = max;
        }

        public static bool IsPrime(long n)
        {
            if (n < s_max)
            {
                return s_primes.BinarySearch(n) > 0;
            }
            var sqrt = Math.Sqrt(n);
            if (s_primes.Count == 0 || s_max * s_max < n)
            {
                s_primes = Sieve.UpTo<List<long>>((long)sqrt * 2);
            }
            return !(n < 2) && (n == 2 || IsPrimeHelper(n, 1, sqrt));
        }

        private static bool IsPrimeHelper(long n, int idx, double sqrt)
        {
            long d = s_primes[idx];
            return n % d != 0 && (d > sqrt || IsPrimeHelper(n, ++idx, sqrt));
        }

        public static bool ExhaustiveIsPrime(long n)
        {
            return !(n < 2) && (n == 2 || ExhaustiveIsPrime(n, 3, Math.Sqrt(n)));
        }

        private static bool ExhaustiveIsPrime(long n, long d, double sqrt)
        {
            return n % d != 0 && (d > sqrt || ExhaustiveIsPrime(n, d + 2, sqrt));
        }

        public static List<long> Primes => s_primes;

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

        public class Factorization : Dictionary<long, int>
        {
            public long SumOfFactors
            {
                get { return this.Aggregate<KeyValuePair<long, int>, long>(1, (current, primeFactor) => current * (((long)Math.Pow(primeFactor.Key, primeFactor.Value + 1) - 1) / (primeFactor.Key - 1))); }
            }

            public static Factorization Of(long number)
            {
                return Factorizer.Factorize(number);
            }

            public static Dictionary<long, Factorization> Of(IEnumerable<long> numbers)
            {
                return Factorizer.Factorize(numbers);
            }
        }

        private static class Factorizer
        {
            public static Factorization Factorize(long number)
            {
                if (s_max * s_max < number)
                {
                    Initialize((long)Math.Sqrt(number) + 1L);
                }
                return PrimeFactors(number);
            }

            public static Dictionary<long, Factorization> Factorize(IEnumerable<long> numbers)
            {
                var max = numbers.Max();
                if (s_max < max)
                {
                    Initialize((long)Math.Sqrt(max) + 1L);
                }
                return numbers.ToDictionary(x => x, PrimeFactors);
            }

            private static Factorization PrimeFactors(long number)
            {
                var factors = new Factorization();
                long num = number;
                foreach (var prime in s_primes)
                {
                    if (num % prime != 0) continue;
                    int ex = 0;
                    while (num % prime == 0)
                    {
                        num /= prime;
                        ex++;
                    }
                    factors.Add(prime, ex);
                    if (num == 1) return factors;
                }
                factors.Add(num, 1);
                return factors;
            }
        }
    }
}
