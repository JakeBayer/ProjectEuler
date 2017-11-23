using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    /// <summary>
    /// Lazily enumerates triangular numbers for quick check if a number is triangular
    /// </summary>
    public class Triangular : GeometricNumberBase
    {
        static Triangular() { }

        protected override int baseVal => 3;

        protected override long ExplicitFormula(long n) => (n * (n + 1)) / 2;

        protected override long ImplicitDifferenceFunction(long n) => n;
    }
}
