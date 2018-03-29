using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathUtil.Computation.Extensions
{
    public static class ComputationExtensions
    {
        #region Square Root
        public static string ArbitraryPrecisionSquareRoot(this int radicand, int precision)
        {
            return radicand.ToString().ArbitraryPrecisionSquareRootHelper(precision);
        }

        public static string ArbitraryPrecisionSquareRoot(this long radicand, long precision)
        {
            return radicand.ToString().ArbitraryPrecisionSquareRootHelper(precision);
        }

        public static string ArbitraryPrecisionSquareRoot(this double radicand, long precision)
        {
            return radicand.ToString(CultureInfo.InvariantCulture).ArbitraryPrecisionSquareRootHelper(precision);
        }

        public static string ArbitraryPrecisionSquareRoot(this decimal radicand, long precision)
        {
            return radicand.ToString(CultureInfo.InvariantCulture).ArbitraryPrecisionSquareRootHelper(precision);
        }

        private static string ArbitraryPrecisionSquareRootHelper(this string radicand, long precision)
        {
            var decimalLocation = radicand.IndexOf('.');
            if (decimalLocation == -1)
            {
                decimalLocation = radicand.Length;
                radicand += ".";
            }
            if (decimalLocation % 2 == 1)
            {
                radicand = "0" + radicand;
                decimalLocation++;
            }

            StringBuilder sb = new StringBuilder();
            BigInteger remainder = 0, c = 0, p = 0, y = 0;
            int x = 0;
            int currentIndex = 0;
            while (sb.Length < precision + 1)
            {
                if (currentIndex == decimalLocation)
                {
                    sb.Append('.');
                    currentIndex++;
                }
                c = 100 * remainder + int.Parse(radicand.GetNTupleAt(2, currentIndex));
                x = FindX(p, c);
                sb.Append(x);
                remainder = c - (x * (20 * p + x));
                p = 10 * p + x;
                currentIndex += 2;
            }

            return sb.ToString();
        }

        private static int FindX(BigInteger p, BigInteger c)
        {
            var guess = p != 0 ? c / p : (int)Math.Sqrt((double)c);
            if (20 * p * guess + guess * guess > c || guess > 9)
            {
                while (20 * p * guess + guess * guess > c || guess > 9)
                {
                    guess--;
                }
                return (int)guess;
            }
            while (20 * p * (guess + 1) + (guess + 1) * (guess + 1) <= c)
            {
                guess++;
            }
            return (int)guess;
        }

        private static string GetNTupleAt(this string str, int n, int at, char pad = '0')
        {
            StringBuilder sb = new StringBuilder();
            int curr = at, end = at + n;
            while (curr < end)
            {
                sb.Append(curr < str.Length ? str[curr] : pad);
                curr++;
            }
            return sb.ToString();
        }
        #endregion
    }
}
