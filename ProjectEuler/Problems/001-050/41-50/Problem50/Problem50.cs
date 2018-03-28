using ProjectEuler.Utils;
using System.Collections.Generic;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem50 : IProblem
    {
        private const long MAX = 1000000;
        public string Run()
        {
            var primes = Prime.Sieve.UpTo<List<long>>(MAX);
            var primesSet = Prime.Sieve.UpTo<HashSet<long>>(MAX);

            long max = 0, length = 0;

            for (int i = 0; i < primes.Count; i++)
            {
                long sum = 0;
                int j = i;
                while (sum < MAX && j < primes.Count)
                {
                    sum += primes[j];
                    j++;
                    if (primesSet.Contains(sum) && j - i > length)
                    {
                        max = sum;
                        length = j - i;
                    }
                }
                
            }
            return max.ToString();
        }
    }
}
