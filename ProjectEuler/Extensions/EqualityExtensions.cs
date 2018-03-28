using System.Linq;

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
