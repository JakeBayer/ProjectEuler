using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem33 : IProblem
    {
        private struct Frac
        {
            public string Numerator;
            public string Denominator;
            public double Value
            {
                get
                {
                    var denom = double.Parse(Denominator);
                    if (denom != 0)
                    {
                        return double.Parse(Numerator) / denom;
                    }
                    return -1;
                }
            }
        }

        public string Run()
        {
            List<Frac> ans = new List<Frac>();
            for (int i = 10; i < 100; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    var frac = new Frac
                    {
                        Numerator = i.ToString(),
                        Denominator = j.ToString(),
                    };
                    if (!IsTrivial(frac) && CanSimplify(frac))
                    {
                        var simplified = Simplify(frac);
                        if (simplified.Value > 0 && frac.Value > 0 && simplified.Value == frac.Value)
                        {
                            ans.Add(frac);
                        }
                    }
                }
            }

            var num = ans.Aggregate(1, (acc, f) => acc * int.Parse(f.Numerator));
            var den = ans.Aggregate(1, (acc, f) => acc * int.Parse(f.Denominator));

            den /= GCD(num, den);
            return den.ToString();
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private string Pad(string s)
        {
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            return s;
        }

        private bool IsTrivial(Frac a)
        {
            return (int.Parse(a.Numerator) % 10 == 0) && (int.Parse(a.Denominator) % 10 == 0);
        }

        private bool CanSimplify(Frac a)
        {
            return a.Denominator.Contains(a.Numerator[0]) || a.Denominator.Contains(a.Numerator[1]);
        }

        private Frac Simplify(Frac a)
        {
            if (a.Denominator.Contains(a.Numerator[0]))
            {
                return new Frac
                {
                    Numerator = a.Numerator[1].ToString(),
                    Denominator = a.Denominator.Remove(a.Denominator.IndexOf(a.Numerator[0]), 1),
                };
            }
            return new Frac
            {
                Numerator = a.Numerator[0].ToString(),
                Denominator = a.Denominator.Remove(a.Denominator.IndexOf(a.Numerator[1]), 1),
            };
        }
    }
}
