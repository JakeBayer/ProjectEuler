using System;
using System.Collections.Generic;
using System.Linq;

namespace MathUtil.NumberTheory
{
    public static class Combinatorics
    {
        private static readonly List<long[]> s_memo = new List<long[]> { new long[] { 1 } };

        public static long Choose(this int n, int r)
        {
            if (n < 0 || r < 0 || r > n)
            {
                return 0;
            }
            return MemoizedChooseHelper(n, r);
        }

        private static long MemoizedChooseHelper(int n, int r)
        {
            if (r < 0 || r > n) return 0;
            if (s_memo.Count() > n)
            {
                if (s_memo[n][r] == 0)
                {
                    s_memo[n][r] = MemoizedChooseHelper(n - 1, r - 1) + MemoizedChooseHelper(n - 1, r);
                }
            }
            else
            {
                var ans = MemoizedChooseHelper(n - 1, r - 1) + MemoizedChooseHelper(n - 1, r);
                s_memo.Add(new long[s_memo.Count() + 1]);
                s_memo[n][r] = ans;
            }
            return s_memo[n][r];
        }

        public static long ChooseExplicit(long n, long r)
        {
            if (n < 0 || r < 0 || r > n)
            {
                return 0;
            }
            r = Math.Min(r, n - r);
            long ans = 1, n_r = n - r, climb = 2;
            while (n > n_r)
            {
                ans *= n;
                while (climb <= r && ans % climb == 0)
                {
                    ans /= climb;
                    climb++;
                }
                n--;
            }
            return ans;
        }
    }
}
