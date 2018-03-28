using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem67 : IProblem
    {
        private readonly List<List<long>> _values, _totals;

        public Problem67()
        {
            _values = ReadValues();
            _totals = new List<List<long>>();
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
            _totals.Add(new List<long> { _values[0][0] });
            for (int i = 1; i < _values.Count; i++)
            {
                _totals.Add(new List<long>());
                var row = _values[i];
                for (int j = 0; j < row.Count; j++)
                {
                    long p1 = 0, p2 = 0;

                    if (j - 1 >= 0)
                        p1 = _totals[i - 1][j - 1];
                    if (j < _totals[i - 1].Count)
                        p2 = _totals[i - 1][j];
                    _totals[i].Add(_values[i][j] + Math.Max(p1, p2));
                }
            }
            return _totals[_totals.Count - 1].Max().ToString();
        }
    }
}
