using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Partition
    {
        private int[] _parts;
        private int _numParts;
        private List<BigInteger[]> _memoizedCounts = new List<BigInteger[]>();

        public Partition(IEnumerable<int> partValues)
        {
            _parts = partValues.OrderByDescending(i => i).ToArray();
            _numParts = _parts.Count();
            _memoizedCounts.Add(Enumerable.Repeat(new BigInteger(1), _numParts).ToArray());
        }

        public BigInteger Count(int n)
        {
            while (_memoizedCounts.Count <= n)
            {
                _memoizedCounts.Add(Enumerable.Repeat(new BigInteger(-1), _numParts).ToArray());
            }
            return Count(n, 0);
        }

        private BigInteger Count(int n, int partIdx)
        {
            if (_memoizedCounts[n][partIdx] == -1)
            {
                var partValue = _parts[partIdx];
                BigInteger count = 0;
                if (partIdx == _numParts - 1)
                {
                    if (n % partValue == 0)
                    {
                        count = 1;
                    }
                }
                else
                {
                    for (int amtOfPart = 0; amtOfPart * partValue <= n; amtOfPart++)
                    {
                        count += Count(n - (amtOfPart * partValue), partIdx + 1);
                    }
                }
                _memoizedCounts[n][partIdx] = count;
            }
            return _memoizedCounts[n][partIdx];
        }
    }
}
