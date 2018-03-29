using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtil.NumberTheory.Extensions
{
    public static class PrimeExtensions
    {
        public static bool IsPrime(this long n)
        {
            return Prime.IsPrime(n);
        }

        public static Prime.Factorization Factorize(this long number)
        {
            return Prime.Factorization.Of(number);
        }

        public static Dictionary<long, Prime.Factorization> Factorize(this IEnumerable<long> numbers)
        {
            return Prime.Factorization.Of(numbers);
        }
    }
}
