using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Types
{
    public class Huge
    {
        public List<int> Digits { get; private set; }

        public Huge()
        {
            Digits = new List<int>();
        }

        public Huge(long seed)
        {
            Digits = new List<int>();
            while (seed > 0)
            {
                Digits.Add((int)seed%10);
                seed /= 10;
            }
        }

        public Huge(Huge seed)
        {
            Digits = new List<int>(seed.Digits);
        }

        public Huge Add(Huge addend)
        {
            for (int i = 0; i < addend.Digits.Count; i++)
            {
                if (Digits.Count > i)
                {
                    var sum = addend.Digits[i] + Digits[i];
                    Digits[i] = sum%10;
                    sum /= 10;
                    if (sum > 0)
                    {
                        if (Digits.Count > i + 1)
                        {
                            Digits[i + 1] += sum;
                        }
                        else
                        {
                            Digits.Add(sum);
                        }
                    }
                }
                else
                {
                    Digits.Add(addend.Digits[i]);
                }
            }
            return this;
        }
    }
}
