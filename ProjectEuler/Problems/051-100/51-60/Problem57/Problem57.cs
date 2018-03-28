namespace ProjectEuler.Problems
{
    public class Problem57 : IProblem
    {
        public string Run()
        {
            var ans = 0;
            double Numerator = 1.0, Denominator = 1.0, temp;
            for (int i = 0; i < 1000; i++)
            {
                temp = 2 * Denominator + Numerator;
                Denominator = Denominator + Numerator;
                Numerator = temp;
                if (Numerator > 10.0)
                {
                    if (Denominator < 10.0)
                    {
                        ans++;
                    }
                    Numerator /= 10.0;
                    Denominator /= 10.0;
                }
            }
            return ans.ToString();
        }
    }
}
