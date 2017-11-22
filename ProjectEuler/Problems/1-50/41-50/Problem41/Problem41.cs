using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem41 : IProblem
    {
        private const long MAX = 7654321; // pandigitals of length 9 and 8 are always divisible by 3
        public string Run()
        {
            var primes = Primes.ToLongList(MAX);
            return primes.Last(p => Pandigital.Is(p, p.ToString().Length)).ToString();
        }
    }
}
