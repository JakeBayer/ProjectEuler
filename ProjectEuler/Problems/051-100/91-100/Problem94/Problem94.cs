using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// By Herons formula, algebra will show Area = (a +- 1)/4 * sqrt[(3a +- 1)(a -+ 1)]
    /// This simply loops through all values and tests simply if Area can be integral
    /// </summary>
    public class Problem94 : IProblem
    {
        private const long ONE_BILLION = 1000000000L;
        public string Run()
        {
            BigInteger sum = 0;
            for (long a = 2; a * 3 < ONE_BILLION; a++)
            {
                var partialRadicand = 3 * a * a - 1;
                var plusRoute = partialRadicand - 2 * a;
                var sqrt = (long)Math.Sqrt(plusRoute);
                if (sqrt * sqrt == plusRoute)
                {
                    if (sqrt * (a + 1) % 4 == 0)
                    {
                        sum += 3 * a + 1;
                    }
                }

                var minusRoute = partialRadicand + 2 * a;
                sqrt = (long)Math.Sqrt(minusRoute);
                if (sqrt * sqrt == minusRoute)
                {
                    if (sqrt * (a - 1) % 4 == 0)
                    {
                        sum += 3 * a - 1;
                    }
                }
            }

            return sum.ToString();
        }
    }
}
