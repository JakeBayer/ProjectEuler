using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem38 : IProblem
    {
        private HashSet<int> _digits = new HashSet<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        long max = 100000;

        public string Run()
        {
            List<long> ans = new List<long>();
            List<int> currentDigits = new List<int>();
            for (int i = 1; i < max; i++)
            {
                int multiplicand = 1;
                currentDigits.Clear();
                while (currentDigits.Count < 9)
                {
                    currentDigits.AddRange((i * multiplicand).ToString().Select(c => int.Parse(c.ToString())));
                    multiplicand++;
                }
                if (currentDigits.Count == 9 && Pandigital.Is(currentDigits))
                {
                    ans.Add(long.Parse(currentDigits.Aggregate("", (acc, curr) => acc + curr.ToString())));
                }
            }
            return ans.Max().ToString();
        }
    }
}
