using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem65 : IProblem
    {
        private int GetContinuedFractionValue(int i)
        {
            return i % 3 == 2 ? i / 3 * 2 + 2 : 1;
        }

        public string Run()
        {
            BigInteger numerator = 0, denominator = 1;
            for (int i = 99; i > 0; i--)
            {
                var temp = GetContinuedFractionValue(i) * denominator + numerator;
                numerator = denominator;
                denominator = temp;
            }
            return (2 * denominator + numerator).ToString().Sum(c => int.Parse(c.ToString())).ToString();
        }
    }
}
