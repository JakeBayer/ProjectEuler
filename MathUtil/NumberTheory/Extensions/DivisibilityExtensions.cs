using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtil.NumberTheory.Extensions
{
    public static class DivisibilityExtensions
    {
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
