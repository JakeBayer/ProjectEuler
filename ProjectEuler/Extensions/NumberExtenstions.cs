using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public static Prime.Factorization Factorize(this long number)
        {
            return Prime.Factorization.Of(number);
        }

        public static Dictionary<long, Prime.Factorization> Factorize(this IEnumerable<long> numbers)
        {
            return Prime.Factorization.Of(numbers);
        }

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
            return radicand.ToString().ArbitraryPrecisionSquareRootHelper(precision);
        }

        public static string ArbitraryPrecisionSquareRoot(this decimal radicand, long precision)
        {
            return radicand.ToString().ArbitraryPrecisionSquareRootHelper(precision);
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
            while(curr < end)
            {
                sb.Append(curr < str.Length ? str[curr] : pad);
                curr++;
            }
            return sb.ToString();
        }
        #endregion
    }
}
