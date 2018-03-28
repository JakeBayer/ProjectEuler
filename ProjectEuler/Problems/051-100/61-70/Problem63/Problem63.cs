using System.Numerics;

namespace ProjectEuler.Problems
{
    public class Problem63 : IProblem
    {
        public string Run()
        {
            long ans = 0;
            for (long i = 1; i < 10; i++)
            {
                var curr = 1;
                while (Pow(10, curr - 1) <= Pow(i, curr))
                {
                    ans++;

                    curr++;
                }
            }
            return ans.ToString();
        }


        private BigInteger Pow(long b, int p)
        {
            BigInteger ans = 1;
            for (int i = 0; i < p; i++)
            {
                ans *= b;
            }
            return ans;
        }
    }
}
