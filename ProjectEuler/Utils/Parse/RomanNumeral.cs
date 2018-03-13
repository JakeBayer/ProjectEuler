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
        private static Dictionary<char, int> _numeralValue = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };

        public static bool IsValid(string romanNumeral)
        {
            return HasValidCharacters(romanNumeral);
        }

        private static bool HasValidCharacters(string romanNumeral)
        {
            return romanNumeral.Any(c => !c.In('I', 'V', 'X', 'L', 'C', 'D', 'M'));
        }

        private static bool HasProperSyntax(string romanNumeral)
        {

        }

        private static bool NumeralsInDescendingOrder(string romanNumeral)
        {
            if (romanNumeral.Length <= 1)
            {
                return true;
            }
            int lastValue = _numeralValue[romanNumeral[0]];
            bool lastValueWasSmaller = false;
            for (int i = 1; i < romanNumeral.Length; i++)
            {
                int currentValue = _numeralValue[romanNumeral[0]];
                if (currentValue >= lastValue)
                {
                    if (lastValueWasSmaller)
                    {
                        return false;
                    }
                }
            }
        }

        public static int Parse(string romanNumeral)
        {

        }
    }
}
