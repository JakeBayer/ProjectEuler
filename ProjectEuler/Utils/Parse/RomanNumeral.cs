using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class RomanNumeral
    {
        #region Private fields
        private static class Numeral
        {
            public const string I = "I";
            public const string IV = "IV";
            public const string V = "V";
            public const string IX = "IX";
            public const string X = "X";
            public const string XL = "XL";
            public const string L = "L";
            public const string XC = "XC";
            public const string C = "C";
            public const string CD = "CD";
            public const string D = "D";
            public const string CM = "CM";
            public const string M = "M";
        }

        private static Dictionary<string, int> s_numeralValue = new Dictionary<string, int>
        {
            [Numeral.I]  = 1,
            [Numeral.IV] = 4,
            [Numeral.V]  = 5,
            [Numeral.IX] = 9,
            [Numeral.X]  = 10,
            [Numeral.XL] = 40,
            [Numeral.L]  = 50,
            [Numeral.XC] = 90,
            [Numeral.C]  = 100,
            [Numeral.CD] = 400,
            [Numeral.D]  = 500,
            [Numeral.CM] = 900,
            [Numeral.M]  = 1000,
        };
        #endregion

        public static bool IsValid(string romanNumeral)
        {
            if (!HasValidCharacters(romanNumeral))
            {
                return false;
            }
            var numerals = SplitNumerals(romanNumeral).ToList();
            return NumeralsAreValid(numerals) 
                && NumeralsInDescendingOrder(numerals) 
                && NeverExceededBySmallerDenominations(numerals)
                && DLVAppearAtMostOnce(numerals);
        }

        private static bool HasValidCharacters(string romanNumeral)
        {
            return romanNumeral.Any(c => !c.In('I', 'V', 'X', 'L', 'C', 'D', 'M'));
        }

        private static IEnumerable<string> SplitNumerals(string romanNumerals)
        {
            if (romanNumerals.Length == 0)
            {
                yield break;
            }
            var currentNumeral = romanNumerals[0].ToString();
            for (int i = 1; i < romanNumerals.Length; i++)
            {
                if (s_numeralValue[romanNumerals[i].ToString()] < s_numeralValue[romanNumerals[i-1].ToString()])
                {
                    currentNumeral += romanNumerals[i];
                }
                else
                {
                    yield return currentNumeral;
                    currentNumeral = "";
                }
            }
            if (!String.IsNullOrEmpty(currentNumeral))
            {
                yield return currentNumeral;
            }
        }

        private static bool NumeralsAreValid(IEnumerable<string> numerals)
        {
            return numerals.All(s_numeralValue.ContainsKey);
        }

        private static bool NumeralsInDescendingOrder(List<string> numerals)
        {
            for (int i = 1; i < numerals.Count; i++)
            {
                if (s_numeralValue[numerals[i-1]] < s_numeralValue[numerals[i]])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool NeverExceededBySmallerDenominations(List<string> numerals)
        {
            int sum = 0;
            bool hasSeenX = false,
                hasSeenC = false,
                hasSeenM = false;
            for (int i = numerals.Count - 1; i >= 0; i++)
            {
                var numeral = numerals[i];
                if (numeral == Numeral.X && !hasSeenX)
                {
                    hasSeenX = true;
                    if (sum >= s_numeralValue[Numeral.X])
                    {
                        return false;
                    }
                }
                else if (numeral == Numeral.C && !hasSeenC)
                {
                    hasSeenC = true;
                    if (sum >= s_numeralValue[Numeral.C])
                    {
                        return false;
                    }
                }
                else if (numeral == Numeral.X && !hasSeenM)
                {
                    hasSeenM = true;
                    if (sum >= s_numeralValue[Numeral.M])
                    {
                        return false;
                    }
                }
                sum += s_numeralValue[numeral];
            }
            return true;
        }

        private static bool DLVAppearAtMostOnce(List<String> numerals)
        {
            // filter out anything thats not a V, L, or D. Group them by value, then make sure none of the groups are larger than 1.
            // Fuck you, it's efficient enough.
            return numerals.Where(n => n.In(Numeral.V, Numeral.L, Numeral.D)).GroupBy(n => n).All(g => g.Count() <= 1);
        }

        public static int Parse(string romanNumeral)
        {

        }
    }
}
