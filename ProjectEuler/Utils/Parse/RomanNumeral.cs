using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class RomanNumeral
    {
        #region Private Fields
        private string _romanNumeral;
        private int _value;
        #endregion

        #region Constructors
        public RomanNumeral(string romanNumeral)
        {
            _romanNumeral = romanNumeral;
            _value = Parse(romanNumeral);
        }

        public RomanNumeral(int value)
        {
            _value = value;
            _romanNumeral = ToRomanNumeral(value);
        }
        #endregion

        #region Constants
        private class Numeral
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

            public static readonly string[] InDescendingOrder = new []{ M, CM, D, CD, C, XC, L, XL, X, IX, V, IV, I };
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

        #region Validation
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
            return romanNumeral.All(c => c.In('I', 'V', 'X', 'L', 'C', 'D', 'M'));
        }

        private static void EnsureHasValidCharacters(string romanNumeral)
        {
            if (!HasValidCharacters(romanNumeral))
            {
                throw new InvalidOperationException($"Roman Numeral {romanNumeral} has invalid characters. Acceptable characters are {String.Join(", ", Numeral.I, Numeral.V, Numeral.X, Numeral.L, Numeral.C, Numeral.D, Numeral.M)}");
            }
        }

        private static IEnumerable<string> SplitNumerals(string romanNumeral)
        {
            if (romanNumeral.Length == 0)
            {
                yield break;
            }
            var romanNumerals = romanNumeral.Select(c => c.ToString()).ToList();
            var currentNumeral = romanNumerals[0].ToString();
            for (int i = 1; i < romanNumerals.Count; i++)
            {
                if (s_numeralValue[romanNumerals[i]] > s_numeralValue[romanNumerals[i-1]])
                {
                    currentNumeral += romanNumerals[i];
                }
                else
                {
                    yield return currentNumeral;
                    currentNumeral = romanNumerals[i];
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

        private static void EnsureNumeralsAreValid(IEnumerable<string> numerals)
        {
            if (!NumeralsAreValid(numerals))
            {
                throw new InvalidOperationException($"When broken up into individual nuemrals, some numerals are invalid. {String.Join(", ", numerals)}");
            }
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

        private static void EnsureNumeralsInDescendingOrder(List<string> numerals)
        {
            if (!NumeralsInDescendingOrder(numerals))
            {
                throw new InvalidOperationException($"Numerals are not in descending order. {String.Join(", ", numerals)}");
            }
        }

        private static bool NeverExceededBySmallerDenominations(List<string> numerals)
        {
            int sum = 0;
            bool hasSeenX = false,
                hasSeenC = false,
                hasSeenM = false;
            for (int i = numerals.Count - 1; i >= 0; i--)
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

        private static void EnsureNeverExceededBySmallerDenominations(List<string> numerals)
        {
            if (!NeverExceededBySmallerDenominations(numerals))
            {
                throw new InvalidOperationException($"Some of the numerals can be condensed with either an {Numeral.M}, {Numeral.C}, or {Numeral.X}. {String.Join("", numerals)}");
            }
        }

        private static bool DLVAppearAtMostOnce(List<string> numerals)
        {
            // filter out anything thats not a V, L, or D. Group them by value, then make sure none of the groups are larger than 1.
            // Fuck you, it's efficient enough.
            return numerals.Where(n => n.In(Numeral.V, Numeral.L, Numeral.D)).GroupBy(n => n).All(g => g.Count() <= 1);
        }

        private static void EnsureDLVAppearAtMostOnce(List<string> numerals)
        {
            if (!DLVAppearAtMostOnce(numerals))
            {
                throw new InvalidOperationException($"Either {Numeral.D}, {Numeral.L}, or {Numeral.V} appear more than once. {String.Join("", numerals)}");
            }
        }
        #endregion
        
        #region Parsing
        public static int Parse(string romanNumeral)
        {
            EnsureHasValidCharacters(romanNumeral);
            var numerals = SplitNumerals(romanNumeral).ToList();
            EnsureNumeralsAreValid(numerals);
            EnsureNumeralsInDescendingOrder(numerals);
            EnsureNeverExceededBySmallerDenominations(numerals);
            EnsureDLVAppearAtMostOnce(numerals);
            return numerals.Sum(n => s_numeralValue[n]);
        }

        public static int ParseNoValidation(string romanNumeral)
        {
            return SplitNumerals(romanNumeral).Sum(n => s_numeralValue[n]);
        }

        public static bool TryParse(string romanNumeral, out int value)
        {
            if (IsValid(romanNumeral))
            {
                value = ParseNoValidation(romanNumeral);
                return true;
            }
            value = -1;
            return false;
        }
        #endregion

        #region Printing
        public static string ToRomanNumeral(int value)
        {
            var sb = new StringBuilder();
            foreach(var numeral in Numeral.InDescendingOrder)
            {
                while (value >= s_numeralValue[numeral])
                {
                    sb.Append(numeral);
                    value -= s_numeralValue[numeral];
                }
                if (value == 0)
                {
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }
        #endregion

        public int Value => _value;

        public override string ToString()
        {
            return _romanNumeral;
        }
    }
}
