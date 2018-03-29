using System;
using System.Collections.Generic;
using System.Linq;

namespace MathUtil.AbstractAlgebra
{
    public class Permutor<T> where T : IComparable<T>
    {
        private readonly List<T> _set;

        public Permutor(IEnumerable<T> set)
        {
            _set = set.ToList();
        }

        public List<T> PermutationAt(long i)
        {
            var set = new List<T>(_set.OrderBy(e => e).ToList());
            for (long j = 0; j < i - 1; j++)
            {
                NextPermutation(set);
            }
            return set;
        }

        public List<T> NextPermutation()
        {
            NextPermutation(_set);
            return _set;
        }

        public bool NextPermutation(List<T> set)
        {
            // Find non-increasing suffix
            int i = set.Count - 1;
            while (i > 0 && set[i - 1].CompareTo(set[i]) >= 0)
                i--;
            if (i <= 0)
                return false;

            // Find successor to pivot
            int j = set.Count - 1;
            while (set[j].CompareTo(set[i - 1]) <= 0)
                j--;
            T temp = set[i - 1];
            set[i - 1] = set[j];
            set[j] = temp;

            // Reverse suffix
            j = set.Count - 1;
            while (i < j)
            {
                temp = set[i];
                set[i] = set[j];
                set[j] = temp;
                i++;
                j--;
            }
            return true;
        }
    }

    public static class Permutation
    {
        public static List<List<T>> AllPermutations<T>(IEnumerable<T> seed)
        {
            var set = new List<T>(seed);
            return Permute(set, 0, set.Count - 1).ToList();
        }

        private static IEnumerable<List<T>> Permute<T>(List<T> set, int start, int end)
        {
            if (start == end)
            {
                yield return new List<T>(set);
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(set, start, i);
                    foreach (var v in Permute(set, start + 1, end))
                    {
                        yield return v;
                    }
                    Swap(set, start, i);
                }
            }
        }

        private static void Swap<T>(List<T> set, int a, int b)
        {
            var temp = set[a];
            set[a] = set[b];
            set[b] = temp;
        }

        public static IEnumerable<List<T>> Cycles<T>(IEnumerable<T> seed)
        {
            var set = new LinkedList<T>(seed);
            for (int i = 0; i < set.Count; i++)
            {
                yield return new List<T>(set);
                var top = set.First();
                set.RemoveFirst();
                set.AddLast(top);
            }
        }

        public static bool IsPermutationOf<T>(this IEnumerable<T> set, IEnumerable<T> other)
        {
            var hashedSet = new HashSet<T>(set);
            return hashedSet.SetEquals(other);
        }

        public static bool IsPermutationOf(this long a, long other)
        {
            int[] digits = new int[10];
            while (a > 0)
            {
                digits[a % 10]++;
                a /= 10;
            }
            while (other > 0)
            {
                var digit = other % 10;
                if (digits[digit]-- == 0)
                {
                    return false;
                }
                other /= 10;
            }
            for (var i = 0; i < 10; i++)
            {
                if (digits[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPermutationOf(this int a, int other)
        {
            int[] digits = new int[10];
            while (a > 0)
            {
                digits[a % 10]++;
                a /= 10;
            }
            while (other > 0)
            {
                var digit = other % 10;
                if (digits[digit]-- == 0)
                {
                    return false;
                }
                other /= 10;
            }
            for (var i = 0; i < 10; i++)
            {
                if (digits[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }
    } 
}
