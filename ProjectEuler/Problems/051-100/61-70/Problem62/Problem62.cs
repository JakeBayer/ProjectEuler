using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{

    public class Problem62 : IProblem
    {
        private class SetComparer : IEqualityComparer<ILookup<int, int>>
        {
            public bool Equals(ILookup<int, int> x, ILookup<int, int> y)
            {
                if (x.Count() != y.Count()) return false;
                foreach (var g in x)
                {
                    if (!y.Contains(g.Key) || y[g.Key].Count() != g.Count()) return false; 
                }
                return true;
            }

            public int GetHashCode(ILookup<int, int> obj)
            {
                return obj.Aggregate(0, (acc, curr) => acc ^ curr.Key ^ curr.Aggregate(0, (ac, cu) => ac ^ cu));
            }
        }

        private Dictionary<ILookup<int, int>, List<long>> digitsToNumber = new Dictionary<ILookup<int, int>, List<long>>(new SetComparer());

        public string Run()
        {
            //var c1 = 41063625L;
            //var c2 = 56623104L;
            //var c4 = 66430125L;
            //var d1 = c1.ToDigits().ToLookup(c => c);
            //digitsToNumber.Add(d1, new List<long>());
            //digitsToNumber[d1].Add(c1);

            //var d2 = c2.ToDigits().ToLookup(c => c);
            //digitsToNumber[d2].Add(c2);




            long curr = 1, cube;
            while (true)
            {
                cube = curr * curr * curr;
                var digits = cube.ToDigits().ToLookup(c => c);
                if (!digitsToNumber.ContainsKey(digits))
                {
                    digitsToNumber.Add(digits, new List<long>());
                }
                digitsToNumber[digits].Add(cube);
                if (digitsToNumber[digits].Count == 5)
                {
                    return digitsToNumber[digits].Min().ToString();
                }
                curr++;
            }
        }
    }
}
