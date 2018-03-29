namespace MathUtil.GeometricNumbers
{
    public class Square : GeometricNumberBase
    {
        protected override int baseVal => 4;

        protected override long ExplicitFormula(long n) => n * n;

        protected override long ImplicitDifferenceFunction(long n) => 2 * n - 1;
    }
}
