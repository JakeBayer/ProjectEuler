namespace MathUtil.GeometricNumbers
{
    public class Hexagonal : GeometricNumberBase
    {
        protected override int baseVal => 6;

        protected override long ExplicitFormula(long n) => n * (2 * n - 1);
    }
}
