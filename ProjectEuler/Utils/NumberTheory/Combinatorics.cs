using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Combinatorics
    {
        private static List<long[]> _memo = new List<long[]> { new long[1] { 1 } };

        public static long Choose(int n, int r)
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
            if (_memo.Count() > n)
            {
                if (_memo[n][r] == 0)
                {
                    _memo[n][r] = MemoizedChooseHelper(n - 1, r - 1) + MemoizedChooseHelper(n - 1, r);
                }
            }
            else
            {
                var ans = MemoizedChooseHelper(n - 1, r - 1) + MemoizedChooseHelper(n - 1, r);
                _memo.Add(new long[_memo.Count() + 1]);
                _memo[n][r] = ans;
            }
            return _memo[n][r];
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
