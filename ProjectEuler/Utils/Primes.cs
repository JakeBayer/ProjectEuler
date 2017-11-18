using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class Primes
    {
        public static HashSet<long> GenerateUpTo(long i)
        {
            var arr = new bool[i + 1];
            for (long j = 0; j < i + 1; j++)
            {
                arr[j] = true;
            }
            arr[0] = false;
            arr[1] = false;

            for (long j = 4; j < i+1; j += 2)
            {
                arr[j] = false;
            }

            long root = (long)Math.Sqrt(i + 1);

            for (long j = 3; j <= root; j += 2)
            {
                if (arr[j])
                {
                    for (long k = j*2; k < i+1; k +=j)
                    {
                        arr[k] = false;
                    }
                }
            }

            HashSet<long> primes = new HashSet<long>();
            primes.Add(2);
            for (long j = 3; j < i + 1; j += 2)
            {
                if (arr[j])
                {
                    primes.Add(j);
                }
            }
            return primes;
        }
    }
}
