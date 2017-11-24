using ProjectEuler.Extensions;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem49 : IProblem
    {
        public string Run()
        {
            var ans = new List<int>();
            var primes = Primes.UpTo<SortedSet<int>>(10000).SkipWhile(x => x < 1000);

            foreach (var prime in primes)
            {
                var first = prime + 3330;
                var second = first + 3330;
                var digits = prime.ToDigits();
                if (primes.Contains(first) && primes.Contains(second) && digits.IsPermutationOf(second.ToDigits()) && digits.IsPermutationOf(first.ToDigits()))
                {
                    ans.Add(prime);
                }
            }

            var only = ans.Single(a => a != 1487);
            return only.ToString() + (only + 3330).ToString() + (only + 6660).ToString();
        }
    }
}
