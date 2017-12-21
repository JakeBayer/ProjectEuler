using ProjectEuler.Extensions;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem74 : IProblem
    {
        private const long ONE_MILLION = 1000000;
        private long[] _factorial = Enumerable.Range(0, 10).Select(n => Factorial.ToLong(n)).ToArray();

        public string Run()
        {
            int ans = 0;
            for (long i = 2; i <= ONE_MILLION; i++)
            {
                if (FactorialDigitLoop(i).Count == 60)
                {
                    ans++;
                }
            }
            return ans.ToString();
        }

        private HashSet<long> FactorialDigitLoop(long n)
        {
            var factDigitSums = new HashSet<long>();
            while (!factDigitSums.Contains(n))
            {
                factDigitSums.Add(n);
                n = n.ToDigits().Sum(d => _factorial[d]);
            }
            return factDigitSums;
        }
    }
}
