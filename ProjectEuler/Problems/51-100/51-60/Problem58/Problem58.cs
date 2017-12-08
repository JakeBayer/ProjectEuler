using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem58 : IProblem
    {
        private const long TEN_THOUSAND = 100000L;
        private Prime primeChecker = new Prime(TEN_THOUSAND);
        private long numDiagonals = 0;
        private long numPrimeDiagonals = 0;

        private long GenerateSpiralLayerAndReturnLastCorner(long lastCorner, long spiralSize)
        {
            for (int i = 0; i < 4; i++)
            {
                lastCorner += spiralSize - 1;
                if (primeChecker.IsPrime(lastCorner))
                {
                    numPrimeDiagonals++;
                }
            }
            numDiagonals += 4;
            return lastCorner;
        }
        public string Run()
        {
            long lastCorner = 9, currentSize = 3;
            numDiagonals = 5;
            numPrimeDiagonals = 3;
            while (numPrimeDiagonals * 10 >= numDiagonals)
            {
                currentSize += 2;
                lastCorner = GenerateSpiralLayerAndReturnLastCorner(lastCorner, currentSize);
            }

            return currentSize.ToString();
        }
    }
}
