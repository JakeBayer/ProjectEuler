using MathUtil.GeometricNumbers;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public class Problem45 : IProblem
    {
        private readonly Hexagonal Hexagonal = new Hexagonal();
        private readonly Pentagonal Pentagonal = new Pentagonal();
        public string Run()
        {
            long n = 144, hex_n = 0;
            bool found = false;
            while (!found)
            {
                hex_n = Hexagonal.Explicit(n);
                n++;
                if (Pentagonal.Is(hex_n))
                {
                    found = true;
                }
            }

            return hex_n.ToString();
        }
    }
}
