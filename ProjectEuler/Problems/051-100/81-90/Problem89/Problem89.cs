using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem89 : IProblem
    {

        public string Run()
        {
            var charSaved = 0;
            var numerals = ReadValues();
            foreach(var numeral in numerals)
            {
                charSaved += numeral.Length - RomanNumeral.ToRomanNumeral(RomanNumeral.Parse(numeral)).Length;
            }
            return charSaved.ToString();
        }

        private IEnumerable<string> ReadValues()
        {
            using (StreamReader reader = FileHelper.ForProblem(89).OpenFile("roman.txt"))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
