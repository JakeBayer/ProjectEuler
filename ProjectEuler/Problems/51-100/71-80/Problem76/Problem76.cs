using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem76 : IProblem
    {
        public string Run()
        {
            var part = new Partition(Enumerable.Range(1, 100));
            var partitionCounter = new Coins(Enumerable.Range(1, 100));
            var c = part.Count(5);
            var p = part.Count(100).ToString();
            var t = partitionCounter.CountWays(100).ToString();
            return p;
        }
    }
}
