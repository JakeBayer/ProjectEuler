using ProjectEuler.Utils;
using System.Linq;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
    public class Problem47 : IProblem
    {
        public string Run()
        {
            var factorizations = Prime.Factorization.Of(Enumerable.Range(1, 10000000).Select(i => (long)i));
            var facAsList = new Prime.Factorization[10000001];
            foreach(var fac in factorizations)
            {
                facAsList[(int)fac.Key] = fac.Value;
            }

            int run = 0;
            int curr = 1;
            while (run != 4)
            {
                if (facAsList[curr].Values.Count() == 4)
                {
                    run++;
                }
                else { run = 0; }
                curr++;
            }


            return (curr - 4).ToString();

        }
    }
}
