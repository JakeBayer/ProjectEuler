using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Numerics;
=======
>>>>>>> d17d4ff98df8148753a3c127bd90e06c56b9b243
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Partition
    {
        private int[] _parts;
        private int _numParts;
<<<<<<< HEAD
        private List<BigInteger[]> _memoizedCounts = new List<BigInteger[]>();
=======
        private List<long[]> _memoizedCounts = new List<long[]>();
>>>>>>> d17d4ff98df8148753a3c127bd90e06c56b9b243

        public Partition(IEnumerable<int> partValues)
        {
            _parts = partValues.OrderByDescending(i => i).ToArray();
            _numParts = _parts.Count();
<<<<<<< HEAD
            _memoizedCounts.Add(Enumerable.Repeat(new BigInteger(1), _numParts).ToArray());
        }

        public BigInteger Count(int n)
        {
            while (_memoizedCounts.Count <= n)
            {
                _memoizedCounts.Add(Enumerable.Repeat(new BigInteger(-1), _numParts).ToArray());
=======
            _memoizedCounts.Add(Enumerable.Repeat(1L, _numParts).ToArray());
        }

        public long Count(int n)
        {
            while (_memoizedCounts.Count <= n)
            {
                _memoizedCounts.Add(Enumerable.Repeat(-1L, _numParts).ToArray());
>>>>>>> d17d4ff98df8148753a3c127bd90e06c56b9b243
            }
            return Count(n, 0);
        }

<<<<<<< HEAD
        private BigInteger Count(int n, int partIdx)
=======
        private long Count(int n, int partIdx)
>>>>>>> d17d4ff98df8148753a3c127bd90e06c56b9b243
        {
            if (_memoizedCounts[n][partIdx] == -1)
            {
                var partValue = _parts[partIdx];
<<<<<<< HEAD
                BigInteger count = 0;
=======
                long count = 0;
>>>>>>> d17d4ff98df8148753a3c127bd90e06c56b9b243
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
