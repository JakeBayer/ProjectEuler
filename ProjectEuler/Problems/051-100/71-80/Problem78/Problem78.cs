using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem78 : IProblem
    {
        private const int ONE_MILLION = 1000000;
        private readonly List<int> _partitionsModMillion = new List<int> { 1, 1 };
        private readonly List<int> _generalizedPentagonals = new List<int> { 0 };
        public string Run()
        {
            var curr = 1;
            while (_partitionsModMillion[curr] != 0)
            {
                curr++;
                int n = 1;
                var pentagonal = GetPentagonal(1);
                int runningTotal = 0;
                while (pentagonal <= curr)
                {
                    var k = KthNonZeroInteger(n);
                    runningTotal += (k-1)%2 == 0 ? _partitionsModMillion[curr - pentagonal] : -_partitionsModMillion[curr - pentagonal];
                    runningTotal %= ONE_MILLION;
                    n++;
                    pentagonal = GetPentagonal(n);
                }
                _partitionsModMillion.Add(runningTotal);
            }
            return curr.ToString();
        }

        private int GetPentagonal(int n)
        {
            if (_generalizedPentagonals.Count < n + 1)
            {
                _generalizedPentagonals.Add(GeneralizedPentagonal(n));
            }
            return _generalizedPentagonals[n];
        }

        private int GeneralizedPentagonal(int n)
        {
            var k = KthNonZeroInteger(n);
            return k * (3 * k - 1) / 2;
        }

        private int KthNonZeroInteger(int n)
        {
            return n % 2 == 0 ? -(n + 1) / 2 : (n + 1) / 2;
        }
    }
}
