using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem31 : IProblem
    {
        public string Run()
        {
            var coins = new Coins(new[] { 200, 100, 50, 20, 10, 5, 2, 1 });
            return coins.CountWays(200).ToString();
        }
    }
}
