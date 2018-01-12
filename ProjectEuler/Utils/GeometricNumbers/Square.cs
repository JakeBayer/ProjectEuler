using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Square : GeometricNumberBase
    {
        static Square() { }

        protected override int baseVal => 4;

        protected override long ExplicitFormula(long n) => n * n;

        protected override long ImplicitDifferenceFunction(long n) => 2 * n - 1;
    }
}
