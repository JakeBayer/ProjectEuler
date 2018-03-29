using System.Numerics;

namespace MathUtil.EuclideanAlgorithm
{
    public static class Modular
    {
        public static BigInteger ModularMultiplicativeInverse(BigInteger a, BigInteger m)
        {
            var extendedEuclidean = ExtendedEuclidean(a, m);
            return extendedEuclidean.X < 0 ? extendedEuclidean.X + m : extendedEuclidean.X;
        }

        public static ExtendedEuclideanSolution ExtendedEuclidean(BigInteger a, BigInteger b)
        {
            BigInteger x0 = 1, xn = 1;
            BigInteger y0 = 0, yn = 0;
            BigInteger x1 = 0;
            BigInteger y1 = 1;
            BigInteger q;
            BigInteger r = a % b;

            while (r > 0)
            {
                q = a / b;
                xn = x0 - q * x1;
                yn = y0 - q * y1;

                x0 = x1;
                y0 = y1;
                x1 = xn;
                y1 = yn;
                a = b;
                b = r;
                r = a % b;
            }

            return new ExtendedEuclideanSolution(xn, yn, b);
        }
    }
}
