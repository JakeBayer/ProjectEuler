using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Extensions
{
    public static class EqualityExtensions
    {
        public static bool In<T>(this T source, params T[] values)
        {
            return values.Contains(source);
        }
    }
}
