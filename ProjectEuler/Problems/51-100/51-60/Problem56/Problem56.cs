using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem56 : IProblem
    {
        public string Run()
        {
            long max = 0;
            for (int i = 90; i < 100; i++)
            {
                for (int j = 90; j < 100; j++)
                {
                    var pow = Pow(i, j);
                    var sum = pow.ToString().Sum(c => c - '0');
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }
            return max.ToString();
        }

        private BigInteger Pow(int bse, int exp)
        {
            var big = new BigInteger(bse);
            var toRet = new BigInteger(bse);
            for (int i = 1; i < exp; i++)
            {
                toRet *= big;
            }
            return toRet;
        }
    }
}
