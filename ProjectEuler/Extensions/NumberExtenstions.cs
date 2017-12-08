using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Extensions
{
    public static class NumberExtenstions
    {
        public static IEnumerable<int> ToDigits(this long number)
        {
            return number.ToString().ToCharArray().Select(c => c - '0');
        }

        public static IEnumerable<int> ToDigits(this int number)
        {
            return number.ToString().ToCharArray().Select(c => c - '0');
        }

        public static int GCD(this int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static long GCD(this long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
