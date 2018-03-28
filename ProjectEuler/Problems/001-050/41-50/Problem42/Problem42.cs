using ProjectEuler.Utils;
using System.IO;
using System.Linq;
using MathUtil.GeometricNumbers;

namespace ProjectEuler.Problems
{
    public class Problem42 : IProblem
    {
        private readonly Triangular Triangular = new Triangular();
        public string Run()
        {
            StreamReader reader = new StreamReader(@"~\..\..\..\Problems\1-50\41-50\Problem42\words.txt");
            var line = reader.ReadLine();
            reader.Close();
            var words = line.Split(',');
            return words.Select(w => w.Replace("\"", "").ToCharArray().Sum(c => c - 'A' + 1L)).Where(Triangular.Is).Count().ToString();
        }
    }
}
