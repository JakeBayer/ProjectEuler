using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Coins
    {
        private List<int> _coinValues;
        private long[,] _memoizedCounts;
        public Coins(IEnumerable<int> coinValues)
        {
            _coinValues = new List<int>(coinValues.OrderByDescending(i => i));
        }

        private void InitializeMemoization(int total)
        {
            _memoizedCounts = new long[total + 1, _coinValues.Count];
            for (int i = 0; i < total + 1; i++)
            {
                for (int j = 0; j < _coinValues.Count; j++)
                {
                    _memoizedCounts[i, j] = i == 0 ? 1 : -1;
                }
            }
        }

        public long CountWays(int total)
        {
            InitializeMemoization(total);
            return CountWays(total, 0);
        }

        private long CountWays(int total, int idx)
        {
            if (_memoizedCounts[total, idx] != -1)
            {
                return _memoizedCounts[total, idx];
            }
            var coinValue = _coinValues[idx];
            long numWays = 0;
            if (idx == _coinValues.Count - 1)
            {
                if (total % coinValue == 0)
                {
                    numWays = 1;
                }
            }
            else
            {
                for (int numCoins = 0; numCoins * coinValue <= total; numCoins++)
                {
                    numWays += CountWays(total - (numCoins * coinValue), idx + 1);
                }
            }
            _memoizedCounts[total, idx] = numWays;
            return numWays;
        }
    }
}
