using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    /// <summary>
    /// Lazily enumerates triangular numbers for quick check if a number is triangular
    /// </summary>
    public static class Triangular
    {
        private static long _max = 0, _curr = 0;
        private static HashSet<long> _triangles = new HashSet<long> { 0 };

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
                    _max += _curr;
                    _triangles.Add(_max);
                }
            }
            return _triangles.Contains(n);
        }
    }
}
