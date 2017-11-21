using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem29 : IProblem
    {
        private HashSet<int> _usedRoots = new HashSet<int>();
        private const int MAX_VAL = 100;
        public int CountsForRoot(int root)
        {
            var usedPowers = new HashSet<int>();
            int rootPow = 1;
            int current = root;
            while (current <= MAX_VAL)
            {
                _usedRoots.Add(current);
                for (int i = 2; i <= MAX_VAL; i++)
                {
                    if (!usedPowers.Contains(rootPow * i))
                    {
                        usedPowers.Add(rootPow * i);
                    }
                }
                current *= root;
                rootPow++;
            }
            return usedPowers.Count();
        }


        public string Run()
        {
            int total = 0;
            for (int i = 2; i <= MAX_VAL; i++)
            {
                if (!_usedRoots.Contains(i))
                {
                    total += CountsForRoot(i);
                }
            }
            return total.ToString();
        }
    }
}
