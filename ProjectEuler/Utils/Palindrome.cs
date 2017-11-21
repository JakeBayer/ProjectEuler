using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Palindrome<T> where T: IComparable<T>, IEquatable<T>
    {
        public static bool IsPalindrome(List<T> collection)
        {
            int min = 0;
            int max = collection.Count - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                if (!collection[min].Equals(collection[max]))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
