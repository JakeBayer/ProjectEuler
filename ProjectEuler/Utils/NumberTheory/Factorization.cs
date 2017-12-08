using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Factorization
    {
        private static SortedSet<long> primes;

        public static void InitializePrimes(long max)
        {
            primes = Prime.Sieve.UpTo<SortedSet<long>>((long)Math.Sqrt(max) + 1);
        }

        public static PrimeFactorization Factorize(this long number)
        {
            if (primes == null)
            {
                InitializePrimes((long)Math.Sqrt(number) + 1);
            }
            return (PrimeFactorization)PrimeFactors(number);
        }

        public static Dictionary<long, PrimeFactorization> Factorize(this IEnumerable<long> numbers)
        {
            if (primes == null)
            {
                InitializePrimes((long)Math.Sqrt(numbers.Max()) + 1L);
            }
            return numbers.ToDictionary(x => x, PrimeFactors);
        }

        private static PrimeFactorization PrimeFactors(long number)
        {
            var factors = new PrimeFactorization();
            long num = number;
            foreach (var prime in primes)
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
            //throw new Exception(string.Format("Not enough primes calculated to factor the number {0}\nBiggest prime = {1}", number, primes.Last()));
        }
    }

    public class PrimeFactorization : Dictionary<long, int>
    {
        public long SumOfFactors
        {
            get { return this.Aggregate<KeyValuePair<long, int>, long>(1, (current, primeFactor) => current*(((long) Math.Pow(primeFactor.Key, primeFactor.Value + 1) - 1)/(primeFactor.Key - 1))); }
        }
    }
}
