using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem47 : IProblem
    {
        public string Run()
        {
            var factorizations = Factorization.Factorize(Enumerable.Range(1, 10000000).Cast<long>());
            

        }
    }
}
