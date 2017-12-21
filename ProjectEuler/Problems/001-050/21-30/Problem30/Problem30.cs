using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem30 : IProblem
    {
        private List<int> powerDigitSums = new List<int>(); 

        public string Run()
        {
            for (int i = 10; i < 6000000; i++)
            {
                var intArr = i.ToString().Select(c => int.Parse(c.ToString())).ToArray();
                if (i == intArr.Sum(j => (int)Math.Pow(j, 5)))
                {
                    powerDigitSums.Add(i);
                }
            }
            return powerDigitSums.Sum().ToString();
        }
    }
}
