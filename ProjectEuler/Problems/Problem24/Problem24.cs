using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem24 : IProblem
    {
        public string Run()
        {
            var permutation = new Permutation<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            return permutation.PermutationAt(1000000).Aggregate("", (acc, i) => acc + i.ToString());
        }
    }
}
