using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class Hexagonal : GeometricNumberBase
    {
        static Hexagonal() { }

        protected override int baseVal => 6;

        public override long Explicit(long n) => n * (2 * n - 1);
    }
}
