using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem48 : IProblem
    {
        private const long MASK = 10000000000;
        public string Run()
        {
            long sum = 0;
            for (long i = 1; i < 1000; i++)
            {
                long curr = 1;
                for (long j = 1; j <= i; j++)
                {
                    curr *= i;
                    curr %= MASK;
                }
                sum += curr;
                sum %= MASK;
            }
            return sum.ToString();
        }
    }
}
