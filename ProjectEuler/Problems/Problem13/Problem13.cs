using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem13 : IProblem
    {
        private string AddStrings(string s1, string s2)
        {
            int idx1 = s1.Length - 1, idx2 = s2.Length - 1, carryover = 0;
            var sb = new StringBuilder(s1.Length + 1);
            char c1, c2, sum;
            while (idx1 >= 0 || idx2 >= 0 || carryover == 1)
            {
                c1 = idx1 >= 0 ? s1[idx1] : '0';
                c2 = idx2 >= 0 ? s2[idx2] : '0';
                sum = (char)(c1 + (c2 - '0') + carryover);
                if (sum > '9')
                {
                    sum -= (char)10;
                    carryover = 1;
                }
                else
                {
                    carryover = 0;
                }
                sb.Append(sum);
                idx1--;
                idx2--;
            }
            return new string(sb.ToString().Reverse().ToArray());
        }

        public string Run()
        {
            FileStream fs = new FileStream(@"C:\LocalDocuments\Visual Studio 2017\Projects\ProjectEuler\ProjectEuler\Problems\Problem13\Numbers.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string s1 = reader.ReadLine(), s2;
            
            while (!reader.EndOfStream)
            {
                s2 = reader.ReadLine();
                s1 = AddStrings(s1, s2);
            }
            return s1;
        }
    }
}
