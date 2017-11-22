using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem43 : IProblem
    {
        private List<int> _primes = Primes.ToIntList(18);
        public string Run()
        {

            var permutor = new Permutation<int>(Enumerable.Range(0, 10));
            var allPandigitals = permutor.AllPermutations();
            var allOnesICareAbout = allPandigitals.Where(SuperSpecificFunctionForThisProblem).Select(p => p.Aggregate("", (acc, curr) => acc + curr.ToString())).Select(long.Parse);

            return allOnesICareAbout.Sum().ToString();
        }

        private bool SuperSpecificFunctionForThisProblem(List<int> digits)
        {
            for (int i = 0; i < 7; i++)
            {
                if (((100 * digits[i+1]) + (10 * digits[i+2]) + digits[i+3]) % _primes[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
