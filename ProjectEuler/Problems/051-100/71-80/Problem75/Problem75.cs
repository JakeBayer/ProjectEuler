using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem75 : IProblem
    {
        private const long ONE_MILLION_FIVE_HUNDRED_THOUSAND = 1500000;

        private List<Tuple<long, long, long>> GeneratePrimitiveTriples(long upTo)
        {
            List<Tuple<long, long, long>> triplets = new List<Tuple<long, long, long>>();
            for (var n = 1; n * n <= upTo / 2; n += 2)
            {
                for (var m = n + 2; m * m < upTo; m += 2)
                {
                    if (n.GCD(m) == 1)
                    {
                        triplets.Add(new Tuple<long, long, long>(m * n, (m * m - n * n) / 2, (m * m + n * n) / 2));
                    }
                }
            }
            return triplets;
        }

        public string Run()
        {
            var primitives = GeneratePrimitiveTriples(ONE_MILLION_FIVE_HUNDRED_THOUSAND);
            var waysToDivide = new int[ONE_MILLION_FIVE_HUNDRED_THOUSAND + 1];
            foreach(var triple in primitives)
            {
                var sum = triple.Item1 + triple.Item2 + triple.Item3;
                for (long i = 1; i * sum <= ONE_MILLION_FIVE_HUNDRED_THOUSAND; i++)
                {
                    waysToDivide[i * sum]++;
                }
            }

            int count = 0;
            for (long i = 0; i <= ONE_MILLION_FIVE_HUNDRED_THOUSAND; i++)
            {
                if (waysToDivide[i] == 1)
                {
                    count++;
                }
            }

            return count.ToString();
        }
    }
}
