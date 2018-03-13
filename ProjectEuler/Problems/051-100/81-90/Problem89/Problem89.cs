using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._051_100._81_90.Problem89
{
    public class Problem89 : IProblem
    {

        public string Run()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ReadValues()
        {
            using (StreamReader reader = FileHelper.ForProblem(89).OpenFile("roman.txt"))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
