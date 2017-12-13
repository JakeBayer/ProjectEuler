using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem67 : IProblem
    {
        private List<List<long>> Values, Totals;

        public Problem67()
        {
            Values = ReadValues();
            Totals = new List<List<long>>();
        }

        private List<List<long>> ReadValues()
        {
            StreamReader reader = FileHelper.ForProblem(67).OpenFile("values.txt");
            var values = new List<List<long>>();
            while (!reader.EndOfStream)
            {
                var row = new List<long>();
                var line = reader.ReadLine();
                var vals = line.Split(' ');
                row.AddRange(vals.Select(long.Parse));
                values.Add(row);
            }
            reader.Close();
            return values;
        }

        public string Run()
        {
            Totals.Add(new List<long> { Values[0][0] });
            for (int i = 1; i < Values.Count; i++)
            {
                Totals.Add(new List<long>());
                var row = Values[i];
                for (int j = 0; j < row.Count; j++)
                {
                    long p1 = 0, p2 = 0;

                    if (j - 1 >= 0)
                        p1 = Totals[i - 1][j - 1];
                    if (j < Totals[i - 1].Count)
                        p2 = Totals[i - 1][j];
                    Totals[i].Add(Values[i][j] + Math.Max(p1, p2));
                }
            }
            return Totals[Totals.Count - 1].Max().ToString();
        }
    }
}
