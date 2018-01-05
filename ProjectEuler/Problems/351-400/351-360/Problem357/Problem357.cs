using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem357 : IProblem
    {
        private const long ONE_HUNDRED_MILLION = 100000000;
        private HashSet<long> _primes;

        public Problem357()
        {
            Prime.Initialize(ONE_HUNDRED_MILLION);
            _primes = new HashSet<long>(Prime.Primes);
        }

        private bool EveryDivisorProducesPrime(long n)
        {
            var sqrt = Math.Sqrt((double)n) + 1;
            var d = 1L;
            while (d < sqrt)
            {
                if (n%d ==0)
                {
                    if (!_primes.Contains(d + n / d)) return false;
                }
                d++;
            }
            return true;
        }

        public string Run()
        {
            var sum = 0L;
            for (long i = 1; i <= ONE_HUNDRED_MILLION; i++)
            {
                if (EveryDivisorProducesPrime(i)) sum += i;
            }
            return sum.ToString();
        }
    }
}
