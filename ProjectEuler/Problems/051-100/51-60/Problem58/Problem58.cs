using MathUtil.NumberTheory;
using MathUtil.NumberTheory.Extensions;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public class Problem58 : IProblem
    {
        private const long TEN_THOUSAND = 100000L;
        private long numDiagonals = 0;
        private long numPrimeDiagonals = 0;

        public Problem58()
        {
            Prime.Initialize(TEN_THOUSAND);
        }

        private long GenerateSpiralLayerAndReturnLastCorner(long lastCorner, long spiralSize)
        {
            for (int i = 0; i < 4; i++)
            {
                lastCorner += spiralSize - 1;
                if (lastCorner.IsPrime())
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
