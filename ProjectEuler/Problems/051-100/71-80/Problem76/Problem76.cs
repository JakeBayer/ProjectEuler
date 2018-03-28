using ProjectEuler.Utils;
using System.Linq;
using MathUtil.NumberTheory;

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
