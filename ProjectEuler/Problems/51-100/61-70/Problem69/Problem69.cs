using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem69 : IProblem
    {
        private const int ONE_MILLION = 1000000;
        public string Run()
        {
            var phi = Totient.UpTo(ONE_MILLION);
            double max = 0;
            int idx = 0;
            for (int i = 1; i <= ONE_MILLION; i++)
            {
                var ratio = (double)i / (double)phi[i];
                if (ratio > max)
                {
                    max = ratio;
                    idx = i;
                }
            }
            return idx.ToString();
        }
    }
}
