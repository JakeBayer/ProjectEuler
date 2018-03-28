using MathUtil.NumberTheory.Extensions;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    public class Problem73 : IProblem
    {
        public string Run()
        {
            long count = 0;
            for (int denominator = 2; denominator <= 12000; denominator++)
            {
                for (int numerator = denominator / 3 + 1; numerator < (denominator + 1) / 2; numerator++)
                {
                    if (numerator.GCD(denominator) == 1)
                    {
                        count++;
                    }
                }
            }
            return count.ToString();
        }
    }
}
