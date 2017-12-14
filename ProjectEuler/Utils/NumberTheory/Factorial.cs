using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Factorial
    {
        private static List<long> _memoizationLong = new List<long> { 1, 1 };
        private static List<BigInteger> _memoizationBigInteger = new List<BigInteger> { 1, 1 };

        public static long ToLong(int n)
        {
            if (_memoizationLong.Count <= n)
            {
                var fac = n * ToLong(n - 1);
                _memoizationLong.Add(fac);
            }
            return _memoizationLong[n];
        }

        public static BigInteger ToBigInteger(int n)
        {
            if (_memoizationBigInteger.Count <= n)
            {
                var fac = n * ToBigInteger(n - 1);
                _memoizationBigInteger.Add(fac);
            }
            return _memoizationBigInteger[n];
        }
    }
}
