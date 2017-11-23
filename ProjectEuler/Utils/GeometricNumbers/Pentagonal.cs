using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Pentagonal : GeometricNumberBase
    {
        static Pentagonal() { }

        protected override int baseVal => 5;

        protected override long ExplicitFormula(long n) => (n * (3 * n - 1)) / 2;
    }
}
