using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem68 : IProblem
    {
        private class MagicPentagon
        {
            private int[] a = new int[10];
            private int? EstablishedSum = null;

            private static List<List<int>> IndexGroups = new List<List<int>>
            {
                new List<int> {0, 5, 6},
                new List<int> {1, 6, 7},
                new List<int> {2, 7, 8},
                new List<int> {3, 8, 9},
                new List<int> {4, 9, 5},
            };

            public MagicPentagon() { }
            public MagicPentagon(MagicPentagon other)
            {
                for (int i = 0; i < 10; i++)
                {
                    a[i] = other.a[i];
                }
                EstablishedSum = other.EstablishedSum;
            }

            public bool TryAdd(int value, int index)
            {
                if (IsValid(value, index))
                {
                    a[index] = value;
                    return true;
                }
                return false;
            }

            private bool IsValid(int i, int n)
            {
                var isValid = true;
                if (n == 4)
                {
                    return (a[0] + a[1] + a[2] + a[3] + i) % 5 == 0;
                }
                if (n > 4)
                {
                    foreach (var group in IndexGroups)
                    {
                        if (group.Contains(n))
                        {
                            if (group.Where(g => g != n).All(g => a[g] != 0))
                            {
                                if (EstablishedSum.HasValue)
                                {
                                    isValid &= group.Where(g => g != n).Sum(g => a[g]) + i == EstablishedSum;
                                }
                                else
                                {
                                    EstablishedSum = group.Where(g => g != n).Sum(g => a[g]) + i;
                                }
                            }
                        }
                    }
                }
                return isValid;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                var minIdx = new[] { 0, 1, 2, 3, 4 }.OrderBy(n => a[n]).First();
                for (int i = 0; i < 5; i++)
                {
                    foreach (var val in IndexGroups[(minIdx + i) % 5])
                    {
                        sb.Append(a[val].ToString());
                    }
                }
                return sb.ToString();
            }
        }

        private IEnumerable<MagicPentagon> GetAllPentagons(MagicPentagon pentagon, HashSet<int> remainingValues, int currentIndex)
        {
            if (remainingValues.Count == 0) yield return pentagon;
            foreach (var value in remainingValues)
            {
                var newPentagon = new MagicPentagon(pentagon);
                if (newPentagon.TryAdd(value, currentIndex))
                {
                    foreach (var p in GetAllPentagons(newPentagon, new HashSet<int>(remainingValues.Except(new[] { value })), currentIndex + 1))
                    {
                        yield return p;
                    }
                }
            }
        }

        public string Run()
        {
            var remainingValues = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var allPentagonStrings = GetAllPentagons(new MagicPentagon(), remainingValues, 0).Select(p => p.ToString());
            var ans = allPentagonStrings.Where(s => s.Length == 16).OrderByDescending(s => s).First();
            return ans;
        }
    }
}
