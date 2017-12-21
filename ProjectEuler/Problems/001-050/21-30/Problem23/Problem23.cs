using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem23 : IProblem
    {
        private IEnumerable<long> nonAbundantSums;

        public string Run()
        {
            long[] nums = new long[28124];
            for (long i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            var factorizations = Prime.Factorization.Of(nums.Skip(3));
            var abundantNums = factorizations.Where(x => x.Value.SumOfFactors > 2 * x.Key).Select(x => x.Key);

            var abundantHash = new HashSet<long>(abundantNums);
            nonAbundantSums = nums.Where(x => !abundantHash.Any(y => abundantHash.Contains(x - y)));
            return nonAbundantSums.Sum().ToString();
        }
    }
}
