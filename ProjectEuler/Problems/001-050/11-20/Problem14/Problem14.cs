using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem14 : IProblem
    {
        private long[] CollatzLength = new long[10000000];

        private void GenerateCollatzLengths()
        {
            CollatzLength[1] = 1;
            for (long i = 2; i < 1000000; i++)
            {
                CollatzLength[i] = Collatz(i);
            }
        }

        private long Collatz(long i)
        {
            if (i < CollatzLength.Length && CollatzLength[i] != 0) return CollatzLength[i];
            long j = i % 2 == 0 ? i / 2 : 3 * i + 1;
            long k = Collatz(j) + 1;
            if (i < CollatzLength.Length)
                CollatzLength[i] = k;
            return k;
        }

        public string Run()
        {
            GenerateCollatzLengths();
            long max_idx = 0;
            long max = 0;
            for (int i = 1; i < CollatzLength.Length; i++)
            {
                if (CollatzLength[i] > max)
                {
                    max = CollatzLength[i];
                    max_idx = i;
                }
            }
            return max_idx.ToString();
        }
    }
}
