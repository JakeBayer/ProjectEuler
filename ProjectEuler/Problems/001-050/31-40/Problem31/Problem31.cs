using MathUtil.NumberTheory;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public class Problem31 : IProblem
    {
        public string Run()
        {
            var coins = new Partition(new[] { 200, 100, 50, 20, 10, 5, 2, 1 });
            return coins.Count(200).ToString();
        }
    }
}
