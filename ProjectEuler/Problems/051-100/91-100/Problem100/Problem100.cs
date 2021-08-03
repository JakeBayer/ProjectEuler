using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem100 : IProblem
    {
        //const long MIN = 1_000_000_000_000;
        const long MIN = 1_070_379_110_490;

        public string Run()
        {
            //Prime.Initialize(MIN);
            var num = MIN;
            var (possible, higher, lower) = FindConsecutiveFactorizations(num);
            while (!possible)
            {
                num++;
                (possible, higher, lower) = FindConsecutiveFactorizations(num);
            }
            return higher.Value().ToString();
        }

        private (bool possible, Prime.Factorization higher, Prime.Factorization lower) FindConsecutiveFactorizations(long number)
        {
            var factorization = new Prime.Factorization();

            var high = number % 2 == 1 ? number : number - 1;
            var low = number % 2 == 1 ? (number - 1) / 2 : number / 2;

            var product = Prime.Factorization.Of(high).MultiplyBy(low);
            var exponentList = product.ToList();


            (bool possible, Prime.Factorization higher, Prime.Factorization lower) FactorizationInternal(Prime.Factorization current, int primeIndex)
            {
                if (primeIndex >= exponentList.Count)
                {
                    return (false, null, null);
                }
                var withPrimeSkipped = FactorizationInternal(current, primeIndex + 1);
                if (withPrimeSkipped.possible)
                {
                    return withPrimeSkipped;
                }
                var (prime, exp) = exponentList[primeIndex];
                for (int i = 1; i <= exp; i++)
                {
                    current.MultiplyByPrime(prime);
                    var currentValue = current.Value();
                    if (currentValue >= high)
                    {
                        current.DivideByPrime(prime);
                        break;
                    }
                    if (currentValue > low)
                    {
                        var other = new Prime.Factorization(product);
                        var dividend = other.DivideBy(current);
                        var dividendValue = dividend.Value();
                        if (dividendValue == current.Value() + 1)
                        {
                            return (true, dividend, current);
                        }
                        if (dividendValue == currentValue - 1)
                        {
                            return (true, current, dividend);
                        }
                        current.DivideByPrime(prime);
                        break;
                    }
                    var withPrime = FactorizationInternal(current, primeIndex + 1);
                    if (withPrime.possible)
                    {
                        return withPrime;
                    }
                    current.DivideByPrime(prime);
                }
                return (false, null, null);
            }

            return FactorizationInternal(factorization, 0);
        }
    }
}
