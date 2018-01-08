using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem500 : IProblem
    {
        private const int TEN_MILLION = 10000000;
        private List<int> _primes = Prime.Sieve.UpTo<List<int>>(TEN_MILLION);
        private List<List<long>> _memoizedPowers = new List<List<long>>();
        private LinkedList<int> _locationOfLowestPrimePower = new LinkedList<int>();
        // (1,1), (2,3), (
        private int[] _potentialPowers;
        public Problem500()
        {
            _potentialPowers = Enumerable.Range(0, 31).Select(i =>
            {
                long pow;
                Pow(2, i, out pow);
                return (int)pow - 1;
            }).ToArray();
            _potentialPowers[0] = 0;
        }
        public string Run()
        {
            _locationOfLowestPrimePower.AddFirst(0);
            var currentPrimeIndex = 0;
            var powerIndexes = new int[_primes.Count + 1];
            for (int i = 0; i < 500500; i++)
            {
                currentPrimeIndex = FindSmallestBumpUpAndReturnPrimeIndex(currentPrimeIndex, powerIndexes);
            }

            return ComputeNumberModulo(currentPrimeIndex, powerIndexes, 500500507L);
        }

        public int FindSmallestBumpUpAndReturnPrimeIndex(int currentPrimeIndex, int[] powerIndexes)
        {
            var powerIndexToBeBumped = 0;
            var minBump = long.MaxValue;
            foreach (var i in _locationOfLowestPrimePower)
            {
                long bump;
                if (Pow(_primes[i], _potentialPowers[powerIndexes[i] + 1] - _potentialPowers[powerIndexes[i]], out bump))
                {
                    if (bump < minBump)
                    {
                        minBump = bump;
                        powerIndexToBeBumped = i;
                    }
                }
            }
            if (powerIndexToBeBumped == currentPrimeIndex)
            {
                currentPrimeIndex++;
            }
            powerIndexes[powerIndexToBeBumped]++;
            if (powerIndexToBeBumped == 0)
            {
                var first = _locationOfLowestPrimePower.First();
                _locationOfLowestPrimePower.RemoveFirst();
                _locationOfLowestPrimePower.AddFirst(1);
                _locationOfLowestPrimePower.AddFirst(0);
            }
            else
            {
                _locationOfLowestPrimePower.Find(powerIndexToBeBumped).Value++;
            }
            return currentPrimeIndex;
        }

        private string ComputeNumberModulo(int currentPrimeIndex, int[] powerIndexes, long mod)
        {
            long num = 1;
            for (int i = 0; i < currentPrimeIndex; i++)
            {
                for (int j = 0; j < _potentialPowers[powerIndexes[i]]; j++)
                {
                    num *= _primes[i];
                    num %= mod;
                }
            }
            return num.ToString();
        }

        private bool Pow(int bse, int exp, out long pow)
        {
            while (_memoizedPowers.Count < bse + 1)
            {
                _memoizedPowers.Add(new List<long>());
            }
            while (_memoizedPowers[bse].Count < exp + 1)
            {
                _memoizedPowers[bse].Add(0L);
            }
            if (_memoizedPowers[bse][exp] == 0)
            {
                pow = bse;
                for (int i = 1; i < exp; i++)
                {
                    pow *= bse;
                    if (pow < 0)
                    {
                        _memoizedPowers[bse][exp] = -1;
                        return false;
                    }
                }
                _memoizedPowers[bse][exp] = pow;
            }
            pow = _memoizedPowers[bse][exp];
            return pow != -1;
        }
    }
}
