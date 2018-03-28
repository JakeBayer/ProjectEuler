using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem17 : IProblem
    {
        private static readonly Dictionary<int, int> s_numberLengthMappings = new Dictionary<int, int>()
        {
            [0] = 0,
            [1] = 3,
            [2] = 3,
            [3] = 5,
            [4] = 4,
            [5] = 4,
            [6] = 3,
            [7] = 5,
            [8] = 5,
            [9] = 4,
            [10] = 3,
            [11] = 6,
            [12] = 6,
            [13] = 8,
            [14] = 8,
            [15] = 7,
            [16] = 7,
            [17] = 9,
            [18] = 8,
            [19] = 8,
            [20] = 6,
            [30] = 6,
            [40] = 5,
            [50] = 5,
            [60] = 5,
            [70] = 7,
            [80] = 6,
            [90] = 6,
        };

        private int GetLength(int i)
        {
            if (i >= 1000)
            {
                return s_numberLengthMappings[i / 1000] + 8 /*THOUSAND*/ + GetLength(i % 1000);
            }
            if (i >= 100)
            {
                int remainder = i % 100;
                return s_numberLengthMappings[i / 100] + 7 /*HUNDRED*/ + (remainder > 0 ? (3 /*AND*/ + GetLength(remainder)) : 0);
            }
            if (i >= 20)
            {
                return s_numberLengthMappings[i - i % 10] + s_numberLengthMappings[i % 10];
            }
            else
            {
                return s_numberLengthMappings[i];
            }
        }

        private void Assert(int i, long length)
        {
            if (GetLength(i) != length)
            {
                throw new Exception($"{i} does not have length {length}");
            }
        }

        public string Run()
        {
            Assert(300, 12);
            Assert(100, 10);
            Assert(374, 26);
            Assert(1000, 11);
            Assert(21, 9);
            Assert(621, 22);
            Assert(504, 18);
            
            long sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += GetLength(i);
            }
            return sum.ToString();
        }
    }
}
