using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Pentagonal
    {
        private static long _max = 0, _curr = 0;
        private static HashSet<long> _pentagonals = new HashSet<long> { 0 };

        public static bool Is(int n)
        {
            return Is(Convert.ToInt64(n));
        }

        public static bool Is(long n)
        {
            if (n > _max)
            {
                while (n >= _max)
                {
                    _curr++;
                    _max = Pentagon(_curr);
                    _pentagonals.Add(_max);
                }
            }
            return _pentagonals.Contains(n);
        }

        public static long Pentagon(long n)
        {
            return (n * (3 * n - 1)) / 2;
        }
    }
}
