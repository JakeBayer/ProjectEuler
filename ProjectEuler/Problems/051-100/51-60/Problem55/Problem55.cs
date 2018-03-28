using ProjectEuler.Utils;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    public class Problem55 : IProblem
    {
        private const long TEN_THOUSAND = 10000;
        public string Run()
        {
            long ans = 0;
            for (long i = 1; i < TEN_THOUSAND; i++)
            {
                bool isLychel = true;
                BigInteger b = new BigInteger(i);
                for (int j = 0; j < 50; j++)
                {
                    b = b + BigInteger.Parse(new string(b.ToString().Reverse().ToArray()));
                    if (Palindrome<char>.IsPalindrome(b.ToString().ToList()))
                    {
                        isLychel = false;
                        break;
                    }
                }
                if (isLychel)
                {
                    ans++;
                }
            }

            return ans.ToString();
        }
    }
}
