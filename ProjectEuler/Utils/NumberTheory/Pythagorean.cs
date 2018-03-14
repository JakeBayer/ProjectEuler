using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Pythagorean
    {
        public class Triple
        {
            private Triple(long _a, long _b, long _c)
            {
                if (_a <= _b)
                {
                    a = _a;
                    b = _b;
                }
                else
                {
                    a = _b;
                    b = _a;
                }
                c = _c;
            }

            public Triple(Triple triple)
            {
                a = triple.a;
                b = triple.b;
                c = triple.c;
            }

            public long a { get; set; }
            public long b { get; set; }
            public long c { get; set; }

            public bool IsValid => a * a + b * b == c * c;

            public static Triple operator *(Triple triple, long scalar)
            {
                return new Triple(triple.a * scalar, triple.b * scalar, triple.c * scalar);
            }

            public override string ToString()
            {
                return $"{{{a}, {b}, {c}}}";
            }

            public static class GeneratePrimitives
            {
                public static List<Triple> WhileOneLegLessThan(long upTo)
                {
                    return WhileMNConditionMet((m, n) => m * n < upTo || (m * m - n * n) / 2 < upTo, upTo);
                }

                public static List<Triple> WhileLegsLessThan(long upTo)
                {
                    return WhileMNConditionMet((m, n) => m * n < upTo && (m * m - n * n) / 2 < upTo, upTo);
                }

                public static List<Triple> WhileHypotnuseLessThan(long upTo)
                {
                    return WhileMNConditionMet((m, n) => m * m + n * n <= upTo * 2, upTo);
                }

                private static List<Triple> WhileMNConditionMet(Func<int, int, bool> mnCondition, long upTo)
                {
                    var triplets = new List<Triple>();
                    for (var n = 1; n * n <= upTo; n += 2)
                    {
                        for (var m = n + 2; mnCondition(m, n); m += 2)
                        {
                            if (n.GCD(m) == 1)
                            {
                                triplets.Add(new Triple(m * n, (m * m - n * n) / 2, (m * m + n * n) / 2));
                            }
                        }
                    }
                    return triplets;
                }
            }
        }
    }
}
