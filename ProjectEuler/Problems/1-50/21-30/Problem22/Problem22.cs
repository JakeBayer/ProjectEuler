using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem22 : IProblem
    {
        private long GetScore(string name)
        {
            return name.ToCharArray().Sum(c => c - 'A' + 1);
        }

        private void Assert(string name, long score)
        {
            if (GetScore(name) != score)
            {
                throw new Exception($"{name} does not have score {score}");
            }
        }

        public string Run()
        {
            FileStream fs = new FileStream(@"C:\LocalDocuments\Visual Studio 2017\Projects\ProjectEuler\ProjectEuler\Problems\Problem22\Names.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            var entireFile = reader.ReadToEnd();
            var names = entireFile.Split(',').Select(s => s.Substring(1, s.Length - 2)).OrderBy(s => s);
            Assert("COLIN", 53);
            //Assert
            return names.Select((n, i) => GetScore(n) * (i + 1)).Sum().ToString();
            
        }
    }
}
