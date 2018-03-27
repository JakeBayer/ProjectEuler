using ProjectEuler.Types;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem93 : IProblem
    {
        private enum Operand
        {
            Add = 0,
            Subtract = 1,
            Divide = 2,
            Multiply = 3,
        }

        public string Run()
        {
            var p = LongestConsecutiveStreakFor(1, 2, 3, 4);
            int longestConsecutive = 0;
            int abcd = int.MinValue;
            for (int a = 1; a < 7; a++)
            {
                for (int b = a + 1; b < 8; b++)
                {
                    for (int c = b + 1; c < 9; c++)
                    {
                        for (int d = c + 1; d < 10; d++)
                        {
                            var streak = LongestConsecutiveStreakFor(a, b, c, d);
                            if (streak > longestConsecutive)
                            {
                                longestConsecutive = streak;
                                abcd = 1000 * a + 100 * b + 10 * c + d;
                            }
                        }
                    }
                }
            }
            return abcd.ToString();
        }

        private int LongestConsecutiveStreakFor(params int[] digits)
        {
            var permutation = new List<int>(digits);
            Permutor<int> permutor = new Permutor<int>(permutation);
            var expressibleIntegers = new HashSet<int>();
            do
            {
                var expressibleValues = ExpressibleValues(permutation.Select(d => new Fraction(d)).ToList());
                expressibleIntegers.UnionWith(expressibleValues.Where(v => v.Denominator == 1).Select(v => v.ToInt32()));
            }
            while (permutor.NextPermutation(permutation));

            for (int i = 1; ;i++)
            {
                if (!expressibleIntegers.Contains(i))
                {
                    return i - 1;
                }
            }
        }

        private IEnumerable<Fraction> ExpressibleValues(List<Fraction> orderedDigits)
        {
            // Combine the fractions in the only 4 ways possible
            if (orderedDigits.Count == 2)
            {
                Fraction a = orderedDigits[0],
                    b = orderedDigits[1];
                yield return a + b;
                yield return a - b;
                yield return a / b;
                yield return a * b;
            }
            else
            {
                // For each adjacent pairs fractions, merge the two using one of the operands
                // and recurse down the expression tree
                for (int i = 0; i < orderedDigits.Count - 2; i++)
                {
                    Fraction a = orderedDigits[i],
                    b = orderedDigits[i + 1];
                    foreach (var operand in new[] { Operand.Add, Operand.Subtract, Operand.Divide, Operand.Multiply })
                    {
                        var condensedDigits = new List<Fraction>(orderedDigits.Take(i));
                        switch (operand)
                        {
                            case Operand.Add:
                                condensedDigits.Add(a + b);
                                break;
                            case Operand.Subtract:
                                condensedDigits.Add(a - b);
                                break;
                            case Operand.Divide:
                                condensedDigits.Add(a / b);
                                break;
                            case Operand.Multiply:
                                condensedDigits.Add(a * b);
                                break;
                        }
                        condensedDigits.AddRange(orderedDigits.Skip(i + 2));
                        foreach(var value in ExpressibleValues(condensedDigits))
                        {
                            yield return value;
                        }
                    }
                }
            }
        }
    }
}
