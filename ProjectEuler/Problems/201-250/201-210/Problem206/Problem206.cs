using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem206 : IProblem
    {
        public string Run()
        {
            BigInteger min = 1000000000000000000;
            BigInteger curr = 1000000000;

            while (true)
            {
                var square = (curr * curr).ToString();
                if (square[0] >= '2')
                {
                    throw new Exception("Yo you fucked up bruh");
                }
                if (FitsForm(square)) break;
                curr += 10;
            }
            return curr.ToString();
        }

        private bool FitsForm(string str)
        {
            return str.Length == 19 
                && str[0] == '1'
                && str[2] == '2'
                && str[4] == '3'
                && str[6] == '4'
                && str[8] == '5'
                && str[10] == '6'
                && str[12] == '7'
                && str[14] == '8'
                && str[16] == '9'
                && str[18] == '0';
        }
    }
}
