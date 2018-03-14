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
        private static Dictionary<string, int> s_numeralValue = new Dictionary<string, int>
        {
            ["I"]  = 1,
            ["IV"] = 4,
            ["V"]  = 5,
            ["IX"] = 9,
            ["X"]  = 10,
            ["XL"] = 40,
            ["L"]  = 50,
            ["XC"] = 90,
            ["C"]  = 100,
            ["CD"] = 400,
            ["D"]  = 500,
            ["CM"] = 900,
            ["M"]  = 1000,
        };
        #endregion

        public static bool IsValid(string romanNumeral)
        {
            if (!HasValidCharacters(romanNumeral))
            {
                return false;
            }
            var numerals = SplitNumerals(romanNumeral).ToList();
            return NumeralsAreValid(numerals) && NumeralsInDescendingOrder(numerals);
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
            var lastCharacter = romanNumerals[0];
            var currentNumeral = lastCharacter.ToString();
            for (int i = 1; i < romanNumerals.Length; i++)
            {
                if (s_numeralValue[romanNumerals[i].ToString()] < s_numeralValue[lastCharacter.ToString()])
                {
                    currentNumeral += romanNumerals[i];
                }
                else
                {
                    yield return currentNumeral;
                    currentNumeral = "";
                }
                lastCharacter = romanNumerals[i];
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
            for (int i = numerals.Count - 1; i >= 0; i++)
            {
                var numeral = numerals[i];
                if (numeral == "X" && sum) 

            }
        }

        public static int Parse(string romanNumeral)
        {

        }
    }
}
