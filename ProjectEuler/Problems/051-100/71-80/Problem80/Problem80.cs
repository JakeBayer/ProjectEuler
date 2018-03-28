using ProjectEuler.Extensions;
using System.Collections.Generic;
using System.Linq;
using MathUtil.Computation.Extensions;

namespace ProjectEuler.Problems
{
    public class Problem80 : IProblem
    {
        private readonly HashSet<int> _squares = new HashSet<int>(Enumerable.Range(1, 10).Select(i => i * i));
        public string Run()
        {
            long sum = 0;
            for (int i = 1; i<= 100; i++)
            {
                if (!_squares.Contains(i))
                {
                    sum += i.ArbitraryPrecisionSquareRoot(100).Where(c => c != '.').Sum(c => c - '0');
                }
            }

            return sum.ToString();
        }
    }
}
