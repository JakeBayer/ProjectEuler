using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems {
    public class Problem70 : IProblem
    {
        private const long TEN_MILLION = 10000000;
        public string Run()
        {
            var phis = Totient.UpTo(TEN_MILLION);
            double minRatio = double.MaxValue;
            long minN = 0;
            for (long i = 2; i <= TEN_MILLION; i++)
            {
                if (i.IsPermutationOf(phis[i]))
                {
                    var ratio = (double)i / (double)phis[i];
                    if  (ratio < minRatio)
                    {
                        minRatio = ratio;
                        minN = i;
                    }
                }
            }
            return minN.ToString();
        }
    }
}
