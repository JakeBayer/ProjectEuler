using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem26 : IProblem
    {
        private int FindSmallestNinesThatIsAMultiple(int i)
        {
            int pow = 1;
            long tens = 10;
            while ((tens - 1) % i != 0)
            {
                tens *= 10;
                pow++;
            }
            return pow;
        }

        private int StripTwosAndTens(int i)
        {
            while (i % 2 == 0)
            {
                i /= 2;
            }
            while (i % 5 == 0)
            {
                i /= 5;
            }
            return i;
        }

        public int GetLengthOfRepeatingDecimal(int i)
        {
            HashSet<int> usedRemainders = new HashSet<int>();
            List<int> remaindersInOrder = new List<int>();
            int remainder = 1;
            while (remainder < i)
            {
                remainder *= 10;
            }
            remainder = remainder % i;
            while (!usedRemainders.Contains(remainder) && remainder != 0)
            {
                usedRemainders.Add(remainder);
                remaindersInOrder.Add(remainder);
                while (remainder < i)
                {
                    remainder *= 10;
                }
                remainder = remainder % i;
            }
            return remaindersInOrder.Count - remaindersInOrder.FindIndex(r => r == remainder);
        }

        public string Run()
        {
            int maxLength = 0;
            List<int> nums = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                int length = GetLengthOfRepeatingDecimal(i);
                if (length > maxLength)
                {
                    maxLength = length;
                    nums.Clear();
                }
                if (length == maxLength)
                {
                    nums.Add(i);
                }
            }
            return nums[0].ToString();
        }
    }
}
