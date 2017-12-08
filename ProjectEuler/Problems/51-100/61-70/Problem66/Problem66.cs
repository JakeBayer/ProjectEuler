using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    // Problem essentially asks us to solve Pell's Equation (Diophantine)
    // This equation and a method to solve has been known since 500AD, and can be found here:
    // https://en.wikipedia.org/wiki/Chakravala_method
    // However, other studies suggest a way to solve with iterated fractions. Given the previous two problems were 
    // all about iterated fractions, I can't help but think that was the intended solution. Whatever, this runs < 1s
    // but yet it may be worth my time to revisit this with a strategy I actually came up with rather than copying
    // Bhaskara, who solved it without computers. Man I'm stupid.
    public class Problem66 : IProblem
    {
        private struct Diophantine
        {
            public Diophantine(BigInteger a, BigInteger b, BigInteger k)
            {
                this.a = a;
                this.b = b;
                this.k = k;
            }
            public BigInteger a { get; set; }
            public BigInteger b { get; set; }
            public BigInteger k { get; set; }
        }

        private Diophantine Chakravala(Diophantine d, long N)
        {
            // see aforementioned wikipedia page for how this works. Essentially if you have two solutions to a more general
            // a^2 - N*b^2 = k, you can compose the two solutions to find yet another. Eventually k == 1 and you have 
            // the solution we are looking for. 
            while (d.k != 1)
            {
                BigInteger m, a, b, k;
                if (d.k == -1)
                {
                    //special case, compose d with itself
                    a = (d.a * d.a + N * d.b * d.b);
                    b = (2 * d.a * d.b);
                    k = 1;
                }
                else
                {
                    m = ChooseM(d, N);
                    a = (d.a * m + N * d.b) / BigInteger.Abs(d.k);
                    b = (d.a + d.b * m) / BigInteger.Abs(d.k);
                    k = (m * m - N) / d.k;
                }
                d.a = a;
                d.b = b;
                d.k = k;
            }
            return d;
        }

        private BigInteger ChooseM(Diophantine d, long N)
        {
            // we need m such that k | (a + bm) that minimizes (m^2 - N)
            // first find possible m
            // a + bm = 0 mod k
            // => m = -a(b^-1) mod k
            var sqrtN = (int)Math.Sqrt(N);
            var k = BigInteger.Abs(d.k);
            var invB = Modular.ModularMultiplicativeInverse(d.b, k); // apparently gcd(b, k) = 1 always, so this is legit ¯\_(ツ)_/¯
            var m = (-d.a) * invB;
            var m0 = m + ((sqrtN - m) / k) * k;
            var m1 = m + ((sqrtN - m) / k + 1) * k;
            return new[] { m0, m1 }.OrderBy(x => BigInteger.Abs(x * x - N)).First();
        }

        public string Run()
        {
            BigInteger maxX = 0;
            int maxD = 0;
            for (int d = 2; d <= 1000; d++)
            {
                var sqrt = (int)Math.Sqrt(d);
                if (d == sqrt * sqrt) continue;
                if (Math.Abs(d - sqrt * sqrt) > Math.Abs(d - (sqrt + 1) * (sqrt + 1))) // find closer square (sqrt) or (sqrt + 1)
                {
                    sqrt++;
                }
                var solution = Chakravala(new Diophantine(sqrt, 1, (sqrt * sqrt) - d), d);
                if (solution.a > maxX)
                {
                    maxX = solution.a;
                    maxD = d;
                }
            }
            return maxD.ToString();
        }
    }
}
