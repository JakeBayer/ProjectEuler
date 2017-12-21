using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem71 : IProblem
    {
        private const int ONE_MILLION = 1000000;
        public string Run()
        {
            int bestNumerator = 0, bestDenominator = 1,
                currDenominator = ONE_MILLION, minDenominator = 1;

            while (currDenominator >= minDenominator)
            {
                var currNumerator = (3 * currDenominator - 1) / 7;
                if (bestNumerator * currDenominator < currNumerator * bestDenominator)
                {
                    bestNumerator = currNumerator;
                    bestDenominator = currDenominator;
                    minDenominator = currDenominator / (3 * currDenominator - 7 * currNumerator);
                }
                currDenominator--;
            }

            return bestNumerator.ToString();
        }
    }
}
