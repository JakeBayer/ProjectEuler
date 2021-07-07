using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Linq;
using MathUtil.AbstractAlgebra;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
  public class Problem43 : IProblem
  {
    private readonly List<int> _primes = Prime.Sieve.UpTo<List<int>>(18);
    public string Run()
    {
      var allPandigitals = Enumerable.Range(0, 10).AllPermutations();
      var allOnesICareAbout = allPandigitals.Where(SuperSpecificFunctionForThisProblem).Select(p => p.Aggregate("", (acc, curr) => acc + curr.ToString())).Select(long.Parse);

      return allOnesICareAbout.Sum().ToString();
    }

    private bool SuperSpecificFunctionForThisProblem(List<int> digits)
    {
      for (int i = 0; i < 7; i++)
      {
        if (((100 * digits[i + 1]) + (10 * digits[i + 2]) + digits[i + 3]) % _primes[i] != 0)
        {
          return false;
        }
      }
      return true;
    }
  }
}
