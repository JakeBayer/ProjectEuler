using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem44 : IProblem
    {
        private Pentagonal Pentagonal = new Pentagonal();
        private List<long> pentagonals = new List<long> { 1 };
        private long current = 1;
        private long min = long.MaxValue;
        public string Run()
        {
            long next;
            // Search for first occurance
            while (min == long.MaxValue)
            {
                next = Pentagonal.Explicit(current);
                current++;
                foreach(var pentagonal in pentagonals)
                {
                    if (Pentagonal.Is(next - pentagonal) && Pentagonal.Is(next + pentagonal) && min > next - pentagonal)
                    {
                        min = next - pentagonal;
                    }
                }
                pentagonals.Add(next);
            }


            // Search until no pentagonals could possibly be closer
            next = Pentagonal.Explicit(current);
            current++;
            while (next - pentagonals.Last() < min)
            {
                foreach (var pentagonal in pentagonals)
                {
                    if (min > next - pentagonal && Pentagonal.Is(next - pentagonal) && Pentagonal.Is(next + pentagonal))
                    {
                        min = next - pentagonal;
                    }
                }
                pentagonals.Add(next);
                next = Pentagonal.Explicit(current);
                current++;
            }
            return min.ToString();
        }

    }
}
