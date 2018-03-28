using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem64 : IProblem
    {
        public string Run()
        {
            int numerator, subtrahend, count = 0;
            var iterations = new HashSet<KeyValuePair<int, int>>();
            for (int i = 2; i <= 10000; i++)
            {
                iterations.Clear();
                var sqrt = Math.Sqrt((double)i);
                if (i == (int)sqrt * (int)sqrt) continue;
                numerator = 1;
                subtrahend = (int)sqrt;
                var iteration = new KeyValuePair<int, int>(numerator, subtrahend);
                while (!iterations.Contains(iteration))
                {
                    iterations.Add(iteration);
                    numerator = (i - subtrahend * subtrahend) / numerator;
                    var toAdd = (int)((sqrt + subtrahend) / numerator);
                    subtrahend = -(subtrahend - toAdd * numerator);

                    iteration = new KeyValuePair<int, int>(numerator, subtrahend);
                }
                count += iterations.Count % 2 == 1 ? 1 : 0;
            }

            return count.ToString();
        }
    }
}
