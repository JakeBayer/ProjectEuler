using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem32 : IProblem
    {
        private readonly HashSet<int> productSet = new HashSet<int>(); 

        public string Run()
        {
            var digits = new HashSet<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int a1;//, b1, b2, b3, b4;
            for (int i = 1; i <= 9; i++)
            {
                a1 = i;
                digits.Remove(i);
                #region singleDigits
                if (i != 1) // check for 1-digit number * 4-digit number = 4 digit number
                {
                    var digits1 = new HashSet<int>(digits);
                    foreach (var b1 in digits1)
                    {
                        digits.Remove(b1);
                        var digits2 = new HashSet<int>(digits);
                        foreach (var b2 in digits2)
                        {
                            digits.Remove(b2);
                            var digits3 = new HashSet<int>(digits);
                            foreach (var b3 in digits3)
                            {
                                digits.Remove(b3);
                                var digits4 = new HashSet<int>(digits);
                                foreach (var b4 in digits4)
                                {
                                    digits.Remove(b4);

                                    CheckSolution(a1, 1000*b1 + 100*b2 + 10*b3 + b4, digits);
                                    digits.Add(b4);
                                }
                                digits.Add(b3);
                            }
                            digits.Add(b2);
                        }
                        digits.Add(b1);
                    }
                }
                #endregion

                var digitsa2 = new HashSet<int>(digits);
                foreach (var a2 in digitsa2)
                {
                    digits.Remove(a2);
                    var digitsb1 = new HashSet<int>(digits);
                    foreach (var b1 in digitsb1)
                    {
                        digits.Remove(b1);
                        var digitsb2 = new HashSet<int>(digits);
                        foreach (var b2 in digitsb2)
                        {
                            digits.Remove(b2);
                            var digitsb3 = new HashSet<int>(digits);
                            foreach (var b3 in digitsb3)
                            {
                                digits.Remove(b3);

                                CheckSolution((10*a1 + a2), 100 * b1 + 10 * b2 + b3, digits);
                                digits.Add(b3);
                            }
                            digits.Add(b2);
                        }
                        digits.Add(b1);
                    }
                    digits.Add(a2);
                }
                digits.Add(a1);
            }
            return productSet.Sum().ToString();
        }


        private void CheckSolution(int num1, int num2, HashSet<int> remainingDigits)
        {
            var prod = num1*num2;
            var prodDigits = prod.ToString().Select(c => int.Parse(c.ToString()));
            var temp = new HashSet<int>(remainingDigits);
            foreach (var prodDigit in prodDigits)
            {
                if (temp.Contains(prodDigit))
                {
                    temp.Remove(prodDigit);
                }
                else
                {
                    return;
                }
            }
            if (!temp.Any())
            {
                if (!productSet.Contains(prod)) { productSet.Add(prod); }
            }
        }
    }
}
