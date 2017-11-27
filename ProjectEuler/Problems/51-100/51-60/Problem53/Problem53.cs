﻿using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem53 : IProblem
    {
        private const long ONE_MILLION = 1000000;
        public string Run()
        {
            long ans = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 0; r <= n; r++)
                {
                    if (Combinatorics.Choose(n, r) > ONE_MILLION)
                    {
                        ans += n - (2 * r) + 1; // Choose is symmetric about r = n/2. if (nCr > 1000000, then so are all nCp for r <= p <= n-r
                        break;
                    }
                }
            }
            return ans.ToString();
        }
    }
}
