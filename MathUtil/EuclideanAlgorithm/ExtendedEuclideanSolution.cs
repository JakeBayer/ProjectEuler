using System.Numerics;

namespace MathUtil.EuclideanAlgorithm
{
    public class ExtendedEuclideanSolution
    {
        // ReSharper disable InconsistentNaming

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public BigInteger D { get; }

        public ExtendedEuclideanSolution(BigInteger x, BigInteger y, BigInteger d)
        {
            X = x;
            Y = y;
            D = d;
        }
    }
}
