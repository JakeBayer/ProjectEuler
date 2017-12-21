using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems 
{
    public class Problem40 : IProblem
    {
        private const int MAX = 1000000;
        public string Run()
        {
            var sb = new StringBuilder("");
            int i = 1;
            while(sb.Length < MAX)
            {
                sb.Append(i.ToString());
                i++;
            }

            var str = sb.ToString();
            var idxs = new[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            return idxs.Aggregate(1, (acc, idx) => acc * (int)(str[idx-1] - '0')).ToString();
        }
    }
}
