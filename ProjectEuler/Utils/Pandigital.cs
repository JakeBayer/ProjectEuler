﻿using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Utils
{
    public static class Pandigital
    {
        private static readonly HashSet<int> s_digits = new HashSet<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        public static bool Is(IEnumerable<int> set)
        {
            return Is(set, s_digits);
        }

        public static bool Is(IEnumerable<int> set, int n)
        {
            return Is(set, new HashSet<int>(Enumerable.Range(1, n)));
        }

        public static bool Is(IEnumerable<int> set, HashSet<int> digits)
        {
            return digits.SetEquals(set);
        }

        public static bool Is(long number)
        {
            return Is(number.ToString().Select(c => c - '0'));
        }

        public static bool Is(long number, int n)
        {
            return Is(number.ToString().Select(c => c - '0'), n);
        }

        public static bool Is(long number, HashSet<int> digits)
        {
            return Is(number.ToString().Select(c => c - '0'), digits);
        }
    }
}
