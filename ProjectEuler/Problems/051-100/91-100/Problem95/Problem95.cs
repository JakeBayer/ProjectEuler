using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem95 : IProblem
    {
        private const long ONE_MILLION = 1000000;
        public Problem95()
        {
            Prime.Initialize(ONE_MILLION);
        }
        public string Run()
        {
            var usedNumbers = new HashSet<long>();
            var currentLoop = new HashSet<long>();
            var min = 0L;
            var longestLoopLength = 0;
            for (long i = 2; i <= ONE_MILLION; i++)
            {
                var curr = i;
                currentLoop.Clear();
                while (!usedNumbers.Contains(curr) && curr > 1 && curr <= ONE_MILLION)
                {
                    if (currentLoop.Contains(curr))
                    {
                        if (currentLoop.Count > longestLoopLength)
                        {
                            var loop = FindLoop(currentLoop);
                            if (loop.Count > longestLoopLength)
                            {
                                longestLoopLength = loop.Count;
                                min = loop.Min();
                            }
                        }
                        break;
                    }
                    currentLoop.Add(curr);
                    curr = Prime.Factorization.Of(curr).SumOfFactors - curr;
                }
                usedNumbers.UnionWith(currentLoop);
            }
            return min.ToString();
        }

        private List<long> FindLoop(HashSet<long> loopCandidate)
        {
            var nodes = Prime.Factorization.Of(loopCandidate).ToDictionary(d => d.Key, d => d.Value.SumOfFactors - d.Key);
            long slow = nodes.First().Key, fast = slow;
            slow = nodes[slow];
            fast = nodes[nodes[fast]];
            while (slow != fast)
            {
                slow = nodes[slow];
                fast = nodes[nodes[fast]];
            }

            slow = nodes.First().Key;
            while (slow != fast)
            {
                slow = nodes[slow];
                fast = nodes[fast];
            }

            List<long> loop = new List<long> { slow };
            fast = nodes[fast];
            while (fast != slow)
            {
                loop.Add(fast);
                fast = nodes[fast];
            }
            return loop;
        }
    }
}
