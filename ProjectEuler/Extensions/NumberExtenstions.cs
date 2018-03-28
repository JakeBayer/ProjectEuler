using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

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
    }
}
