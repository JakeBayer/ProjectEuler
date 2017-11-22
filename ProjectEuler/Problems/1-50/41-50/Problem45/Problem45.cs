using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem45 : IProblem
    {
        public string Run()
        {
            long n = 144, hex_n = 0;
            bool found = false;
            while (!found)
            {
                hex_n = Hexagonal.Explicit(n);
                n++;
                if (Pentagonal.Is(hex_n))
                {
                    found = true;
                }
            }

            return hex_n.ToString();
        }
    }
}
