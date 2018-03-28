using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Linq;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem37 : IProblem
    {
        public string Run()
        {
            var primes = Prime.Sieve.UpTo<HashSet<long>>(10000000L); // random guess of 10 million being sufficient, not worth my time to continuously generate exact amount

            long i = 9;
            List<long> ans = new List<long>();
            while (ans.Count < 11) //problem explicitly states 11 exist
            {
                i += 2;
                long j = i;
                while (j > 0 && primes.Contains(j))
                {
                    j = TruncateLeft(j);
                }
                if (j != 0) continue;

                j = i;
                while (j > 0 && primes.Contains(j))
                {
                    j = TruncateRight(j);
                }
                if (j != 0) continue;
                ans.Add(i);
            }

            return ans.Sum().ToString();
        }

        private long TruncateLeft(long i)
        {
            var truncated = i.ToString().Substring(1);
            return string.IsNullOrEmpty(truncated) ? 0 : long.Parse(truncated);
        }

        private long TruncateRight(long i)
        {
            var asString = i.ToString();
            var truncated = asString.Substring(0, asString.Length - 1);
            return string.IsNullOrEmpty(truncated) ? 0 : long.Parse(truncated);
        }
    }
}
