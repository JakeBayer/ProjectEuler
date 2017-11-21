using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem36 : IProblem
    {
        private const int UP_TO = 1000000;
        public string Run()
        {
            List<int> ans = new List<int>();
            for (int i = 1; i < UP_TO; i++)
            {
                if (Palindrome<char>.IsPalindrome(i.ToString().ToCharArray().ToList()))
                {
                    var binary = Convert.ToString(i, 2);
                    if (Palindrome<char>.IsPalindrome(binary.ToCharArray().ToList()))
                    {
                        ans.Add(i);
                    }
                }
            }
            return ans.Sum().ToString();
        }
    }
}
