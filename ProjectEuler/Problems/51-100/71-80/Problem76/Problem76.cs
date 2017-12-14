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
            return (part.Count(100)-1).ToString();
        }
    }
}
