namespace MathUtil.GeometricNumbers
{
    public class Pentagonal : GeometricNumberBase
    {
        protected override int baseVal => 5;

        protected override long ExplicitFormula(long n) => (n * (3 * n - 1)) / 2;
    }
}
