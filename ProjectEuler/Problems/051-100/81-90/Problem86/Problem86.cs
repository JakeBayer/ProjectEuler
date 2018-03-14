using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    //https://en.wikipedia.org/wiki/Pythagorean_triple#A_variant
    public class Problem86 : IProblem
    {
        private const int MAX = 2000;
        private const long ONE_MILLION = 1000000;
        private static HashSet<long> s_squares = new Square().GenerateUpTo(MAX * MAX);
        public string Run()
        {
            var triples = Pythagorean.Triple.GeneratePrimitives.WhileOneLegLessThan(MAX);
            var cubesWithLongestSideM = new long[2 * MAX + 1];
            int i;
            foreach (var triple in triples)
            {
                i = 1;
                var newTriple = triple * i;
                while (newTriple.a <= MAX && newTriple.b <= 2 * MAX)
                {
                    long val1 = CountShortestPathsBySplittingA(newTriple);
                    cubesWithLongestSideM[newTriple.b] += val1;
                    long val2 = CountShortestPathsBySplittingB(newTriple);
                    cubesWithLongestSideM[newTriple.a] += val2;
                    i++;
                    newTriple = triple * i;
                }
            }

            long sum = 0;
            i = -1;
            while (sum < ONE_MILLION)
            {
                i++;
                sum += cubesWithLongestSideM[i];
            }
            return i.ToString();
        }

        // If the Cube lengths are x,y,z then (x+y)^2 + z^2 being the shortest path ==> x <= z, y <= z
        // (To see why, map out all three shortest path candidates, assert one to be smaller than the other two, 
        // and look at what this implies about x, y, and z. Algebra is very straightforward)
        // so given a triple of a,b,c, we are only interested in finding x,y,z 
        // such that WLOG a = x + y, b = z OR a = z, b = x + y where our inequality holds (x, y <= z)

        // for a = x + y, b = z, then there are a/2 ways of finding x,y such that x+y = a and x,y < z
        private long CountShortestPathsBySplittingA(Pythagorean.Triple triple)
        {
            return triple.a / 2;
        }
        // for a = z, b = x + y, there are some solutions if and only if b > a/2, and the amount 
        //can be (sneakily) calculate with some clever arithmatic to be (b - (a + 1) /2);
        private long CountShortestPathsBySplittingB(Pythagorean.Triple triple)
        {
            return Math.Max(0, (triple.a - (triple.b + 1) / 2) + 1);
        }
    }
}
