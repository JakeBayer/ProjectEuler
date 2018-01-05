using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem99 : IProblem
    {
        private IEnumerable<Tuple<double, double>> ParseBaseExponentPairs()
        {
            var reader = FileHelper.ForProblem(99).OpenFile("base_exp.txt");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var vals = line.Split(',');
                yield return new Tuple<double, double>(double.Parse(vals[0]), double.Parse(vals[1]));
            }
        }
        public string Run()
        {
            var vals = ParseBaseExponentPairs();
            var line = 1;
            double exp = vals.ElementAt(0).Item2;
            double max = 0;
            double maxLine = 1;
            foreach(var val in vals)
            {
                if (Math.Pow(val.Item1, val.Item2 / exp) > max)
                {
                    max = Math.Pow(val.Item1, val.Item2 / exp);
                    maxLine = line;
                }
                line++;
            }

            return maxLine.ToString();
        }
    }
}
