using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Permutation<T> where T : IComparable<T>
    {
        private List<T> _set;

        public Permutation(IEnumerable<T> set)
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

        public bool NextPermutation(List<T> set)
        {
            // Find non-increasing suffix
            int i = set.Count- 1;
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

        public List<List<T>> AllPermutations()
        {
            var set = new List<T>(_set);
            return Permute(set, 0, set.Count - 1).ToList();
        }

        public static List<List<T>> AllPermutations(IEnumerable<T> seed)
        {
            var set = new List<T>(seed);
            return Permute(set, 0, set.Count - 1).ToList();
        }

        private static IEnumerable<List<T>> Permute(List<T> set, int start, int end)
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

        private static void Swap(List<T> set, int a, int b)
        {
            var temp = set[a];
            set[a] = set[b];
            set[b] = temp;
        }

        public IEnumerable<List<T>> Cycles()
        {
            T top;
            var set = new List<T>(_set);
            for (int i = 0; i < set.Count; i++)
            {
                yield return new List<T>(set);
                top = set[0];
                set.RemoveAt(0);
                set.Add(top);
            }
        }

        public static IEnumerable<List<T>> Cycles(IEnumerable<T> seed)
        {
            T top;
            var set = new List<T>(seed);
            for (int i = 0; i < set.Count; i++)
            {
                yield return new List<T>(set);
                top = set[0];
                set.RemoveAt(0);
                set.Add(top);
            }
        }
    }
}
