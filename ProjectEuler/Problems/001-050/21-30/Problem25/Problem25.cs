using ProjectEuler.Types;

namespace ProjectEuler.Problems
{
    public class Problem25 : IProblem
    {
        private long n;

        public string Run()
        {
            var a = new Huge(1L);
            var b = new Huge(1L);
            n = 2;

            while (b.Digits.Count < 1000)
            {
                var temp = new Huge(b);
                b.Add(a);
                a = temp;
                n++;
            }
            return n.ToString();
        }
    }
}
