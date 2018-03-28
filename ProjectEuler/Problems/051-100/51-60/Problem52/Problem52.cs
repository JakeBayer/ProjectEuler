using MathUtil.AbstractAlgebra;
using ProjectEuler.Extensions;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public class Problem52 : IProblem
    {
        public string Run()
        {
            long curr = 0;
            bool found = false;
            while (!found)
            {
                curr++;
                found = true;
                var digits = curr.ToDigits();
                for (long i = 2; i <= 6; i++)
                {
                    if (!digits.IsPermutationOf((i * curr).ToDigits()))
                    {
                        found = false;
                    }
                }
            }
            return curr.ToString();
        }
    }
}
