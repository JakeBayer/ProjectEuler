using ProjectEuler.Extensions;
using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem51 : IProblem
    {
        private const long MAX = 100000000;
        private readonly SortedSet<long> primes = Prime.Sieve.UpTo<SortedSet<long>>(MAX);
        private readonly HashSet<long> usedPrimes = new HashSet<long>();
        private StringBuilder sb = new StringBuilder();
        public string Run()
        {
            usedPrimes.Clear();
            long ans = 0;
            foreach (var prime in primes.SkipWhile(p => p < 10))
            {
                if (CheckPrime(prime))
                {
                    ans = prime;
                    break;
                }
            }

            return ans.ToString();
        }

        public bool CheckPrime(long prime)
        {
            var digits = prime.ToDigits().ToList();
            foreach(var digit in digits.Distinct())
            {
                if (CountFamily(digits, digit) == 8)
                {
                    return true;
                }
            }
            return false;
        }

        private int CountFamily(IEnumerable<int> number, int digitToReplace)
        {
            var format = GenerateNumberFormat(number, digitToReplace);
            var count = 0;
            bool first = number.ElementAt(0) == digitToReplace;

            for (int i = first ? 1 : 0; i < 10 && i - count < 3; i++)
            {
                if (primes.Contains(long.Parse(string.Format(format, i))))
                {
                    count++;
                }
            }
            return count;
        }

        private string GenerateNumberFormat(IEnumerable<int> number, int digitToReplace)
        {
            return number.Aggregate("", (acc, num) => acc + (num == digitToReplace ? "{0}" : num.ToString()));
        }
    }
}
