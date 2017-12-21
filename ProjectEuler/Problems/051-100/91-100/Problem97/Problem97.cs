using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem97 : IProblem
    {
        public string Run()
        {
            long prod = 1;
            for (int i = 0; i < 7830457; i++)
            {
                prod *= 2;
                prod %= 10000000000;
            }
            prod *= 28433;
            prod++;
            return (prod % 10000000000).ToString();
        }
    }
}
