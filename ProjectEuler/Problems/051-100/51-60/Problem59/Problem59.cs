using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem59 : IProblem
    {
        private readonly HashSet<char> _acceptablePunctuation = new HashSet<char>
        {
            ' ','!','"','\'', '(', ')','.',',','?',(char)12,(char)15
        };

        private List<char> ReadCipher()
        {
            string line;
            using (StreamReader reader = new StreamReader(@"~\..\..\..\Problems\51-100\51-60\Problem59\cipher.txt"))
            {
                line = reader.ReadLine();
            }
            return line.Split(',').Select(n => (char)int.Parse(n)).ToList();
        }

        private List<char> Decipher(List<char> cipherText)
        {
            List<char> decipher = new List<char>();
            int missesSoFar = 0;
            char next, a = 'a', b = 'a', c = 'a';
            while (a <= 'z' && b <= 'z' && c <= 'z')
            {
                var cipher = new[] { a, b, c };
                for (int i = 0; i < cipherText.Count; i++)
                {
                    next = (char)(cipherText[i] ^ cipher[i % 3]);
                    if (!char.IsLetterOrDigit(next) && !_acceptablePunctuation.Contains(next))
                    {
                        missesSoFar++;
                        if (missesSoFar > 10)
                        {
                            if (i % 3 == 0) a++;
                            else if (i % 3 == 1) b++;
                            else if (i % 3 == 2) c++;
                            decipher.Clear();
                            missesSoFar = 0;
                            break;
                        }
                    }
                    decipher.Add(next);
                }
                if (decipher.Count == cipherText.Count)
                {
                    return decipher;
                }
            }
            return new List<char>();
        }


        public string Run()
        {
            var cipherText = ReadCipher();
            var ans = Decipher(cipherText);

            return ans.Aggregate(0, (acc, curr) => acc + (int)curr).ToString();
        }
    }
}
