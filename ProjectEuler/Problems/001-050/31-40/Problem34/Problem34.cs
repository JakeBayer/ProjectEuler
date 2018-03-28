using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem34 : IProblem
    {
        private int[] _factorial;

        public Problem34()
        {
            Init();
        }

        private void Init()
        {
            _factorial = new int[10];
            _factorial[0] = 1;
            for (int i = 1; i < 10; i++)
            {
                _factorial[i] = i * _factorial[i - 1];
            }
        }

        public string Run()
        {
            var ans = new List<int>();
            for (int i = 3; i < 10000000; i++)
            {
                var sumFac = i.ToString().Sum(c => _factorial[int.Parse(c.ToString())]);
                if (i == sumFac)
                {
                    ans.Add(i);
                }
            } 
            return ans.Sum().ToString();
        }

    }
}
