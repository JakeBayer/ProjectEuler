using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem18 : IProblem
    {
        private readonly List<List<long>> Values;
        private readonly List<List<long>> Totals;

        public Problem18()
        {
            Values = ReadValues();
            Totals = new List<List<long>>();
        }

        private List<List<long>> ReadValues()
        {
            StreamReader reader = new StreamReader(@"~\..\..\..\Problems\1-50\11-20\Problem18\values.txt");
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
