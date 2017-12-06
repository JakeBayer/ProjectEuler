using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class ExtendedEuclideanSolution
    {
        private BigInteger x, y, d;

        public BigInteger X
        {
            get
            {
                return this.x;
            }
        }

        public BigInteger Y
        {
            get
            {
                return this.y;
            }
        }

        public BigInteger D
        {
            get
            {
                return this.d;
            }
        }

        public ExtendedEuclideanSolution(BigInteger x, BigInteger y, BigInteger d)
        {
            this.x = x;
            this.y = y;
            this.d = d;
        }
    }
}
