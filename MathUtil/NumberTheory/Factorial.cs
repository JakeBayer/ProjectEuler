using System.Collections.Generic;
using System.Numerics;

namespace MathUtil.NumberTheory
{
    public static class Factorial
    {
        private static readonly List<long> s_memoizationLong = new List<long> { 1, 1 };
        private static readonly List<BigInteger> s_memoizationBigInteger = new List<BigInteger> { 1, 1 };

        public static long ToLong(int n)
        {
            if (s_memoizationLong.Count <= n)
            {
                var fac = n * ToLong(n - 1);
                s_memoizationLong.Add(fac);
            }
            return s_memoizationLong[n];
        }

        public static BigInteger ToBigInteger(int n)
        {
            if (s_memoizationBigInteger.Count <= n)
            {
                var fac = n * ToBigInteger(n - 1);
                s_memoizationBigInteger.Add(fac);
            }
            return s_memoizationBigInteger[n];
        }
    }
}
