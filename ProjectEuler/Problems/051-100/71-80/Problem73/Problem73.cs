using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
