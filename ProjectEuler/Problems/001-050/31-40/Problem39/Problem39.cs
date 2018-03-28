using System;

namespace ProjectEuler.Problems
{
    // Not Ideal. Could use the fact that a^2 = c^2 - b^2 = (c-b)(c+b) to cycle more efficiently. Problem only has p <= 1000; Easier to brute force
    public class Problem39 : IProblem
    {
        private const int MAX = 1000;
        private const int MAX2 = MAX * MAX;
        public string Run()
        {
            var upperBound = Math.Sqrt(MAX2 / 2); // a <= b, c < 1000 ==> a^2 < (1000^2)/2
            var counts = new int[MAX+1];
            for (int i = 3; i < upperBound; i++)
            {
                for(int j = i + 1; j*j + i*i < MAX2; j++)
                {
                    var root = (int)Math.Sqrt(j * j + i * i);
                    if (root * root == j * j + i * i && root + i + j <= MAX)
                    {
                        counts[root + i + j]++;
                    }
                }
            }
            int max = -1, max_idx = 0;
            for (int i = 0; i < MAX + 1; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    max_idx = i;
                }
            }
            return max_idx.ToString();
        }
    }
}
