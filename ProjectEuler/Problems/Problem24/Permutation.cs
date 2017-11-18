using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Permutation<T> where T : IComparable<T>
    {
        private enum PermutationMode
        {
            GetAll = 1,
            StopAt = 2,
        };

        private List<T> _set;
        private List<List<T>> _permutations;
        private long _count = 0;

        private PermutationState _state;

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
            _permutations = new List<List<T>>();
            return Permute(set, 0, set.Count - 1).ToList();
        }

        private IEnumerable<List<T>> Permute(List<T> set, int start, int end)
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
                    Permute(set, start + 1, end);
                    Swap(set, start, i);
                }
            }
        }

        private void Swap<T>(List<T> set, int a, int b)
        {
            T temp = set[a];
            set[a] = set[b];
            set[b] = temp;
        }

        private class PermutationState
        {
            public PermutationState(List<T> set)
            {
                _currentSet = new List<T>(set);
                _currentPermutations = new List<List<T>>();
                count = 0;
                start = 0;
                end = set.Count - 1;
            }
            public List<T> _currentSet { get; set; }
            public List<List<T>> _currentPermutations { get; set; }
            public long count { get; set; }
            public int start { get; set; }
            public int end { get; set; }
        }
    }
}
