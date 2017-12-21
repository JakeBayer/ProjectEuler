using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem92 : IProblem
    {
        private const long TEN_MILLION = 10000000;

        public string Run()
        {
            var squares = Enumerable.Range(0, 10).Select(i => i * i).ToArray();
            HashSet<long> numsThatGoTo1 = new HashSet<long> { 1, 10, 100, 13, 32, 44 };
            HashSet<long> numsThatGoTo89 = new HashSet<long> { 85, 89, 145, 42, 20, 4, 16, 37, 58 };
            List<long> numsSoFar = new List<long>();
            int count = 0;
            for (long i = 2; i < TEN_MILLION; i++)
            {
                var j = i;
                numsSoFar.Clear();
                numsSoFar.Add(j);
                while (!numsThatGoTo1.Contains(j) && !numsThatGoTo89.Contains(j))
                {
                    j = j.ToDigits().Sum(k => squares[k]);
                    numsSoFar.Add(j);
                }
                if (numsThatGoTo89.Contains(j))
                {
                    count++;
                    numsThatGoTo89.UnionWith(numsSoFar);
                }
                else
                {
                    numsThatGoTo1.UnionWith(numsSoFar);
                }
            }

            return count.ToString();
        }
    }
}
