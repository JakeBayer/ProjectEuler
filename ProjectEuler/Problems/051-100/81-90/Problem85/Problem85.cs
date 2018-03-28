using ProjectEuler.Utils;
using System;
using System.Linq;
using MathUtil.GeometricNumbers;

namespace ProjectEuler.Problems
{
    public class Problem85 : IProblem
    {
        private readonly long TWO_MILLION = 2000000;
        public string Run()
        {
            var triangulars = new Triangular().GenerateWhileLessThan(TWO_MILLION + 1001).ToList();
            long area = 0;
            long minDiff = long.MaxValue;
            int lowindex = 1;
            long est;
            int estIdx = int.MaxValue;
            while (lowindex < estIdx)
            {
                est = TWO_MILLION / triangulars[lowindex];
                estIdx = triangulars.BinarySearch(est);
                if (estIdx < 0) { estIdx = -estIdx; }
                estIdx--;
                if (Math.Abs(TWO_MILLION - triangulars[lowindex] * triangulars[estIdx]) < minDiff)
                {
                    minDiff = Math.Abs(TWO_MILLION - triangulars[lowindex] * triangulars[estIdx]);
                    area = lowindex * estIdx;
                }
                if (Math.Abs(TWO_MILLION - triangulars[lowindex] * triangulars[estIdx + 1]) < minDiff)
                {
                    minDiff = Math.Abs(TWO_MILLION - triangulars[lowindex] * triangulars[estIdx + 1]);
                    area = lowindex * estIdx + lowindex;
                }
                lowindex++;
            }
            return area.ToString();
        }
    }
}
