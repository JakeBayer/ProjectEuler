using ProjectEuler.Extensions;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem79 : IProblem
    {
        private int _minLength = int.MaxValue;
        private List<PasscodeState> _minPasscodes = new List<PasscodeState>();

        private List<List<int>> ReadValues()
        {
            StreamReader reader = FileHelper.ForProblem(79).OpenFile("passcode.txt");
            var values = new List<int>();
            while (!reader.EndOfStream)
            {
                values.Add(int.Parse(reader.ReadLine()));
            }
            reader.Close();
            return values.Distinct().Select(v => v.ToDigits().ToList()).ToList();
        }
        public string Run()
        {
            var p = ReadValues();
            FindPasscodeGreedy(new PasscodeState(new int[] { }, p));


            return _minPasscodes.First().ToString();
        }

        private void FindPasscodeGreedy(PasscodeState passcode)
        {
            if (passcode.Count >= _minLength) return;
            var nextDigits = passcode.GetOrderedNextDigits();
            foreach(var digit in nextDigits)
            {
                var newPass = passcode.AddValue(digit);
                if (newPass.RemainingSubstringCount == 0)
                {
                    if (newPass.Count < _minLength)
                    {
                        _minLength = newPass.Count;
                        _minPasscodes.Clear();
                    }
                    _minPasscodes.Add(newPass);
                }
                else
                {
                    FindPasscodeGreedy(newPass);
                }
            }
        }


        private class PasscodeState
        {
            private List<int> _passcode = new List<int>();
            private List<List<int>> _substrings = new List<List<int>>();

            public PasscodeState(IEnumerable<int> passcode, IEnumerable<IEnumerable<int>> substrings)
            {
                _passcode = new List<int>(passcode);
                foreach(var substring in substrings)
                {
                    _substrings.Add(new List<int>(substring));
                }
            }

            public int Count => _passcode.Count;

            public int RemainingSubstringCount => _substrings.Count;

            public override string ToString() => _passcode.Aggregate("", (acc, curr) => acc + curr.ToString());

            public PasscodeState AddValue(int val)
            {
                var newSubstrings = new List<IEnumerable<int>>();
                foreach(var substring in _substrings)
                {
                    if (substring[0] == val)
                    {
                        if (substring.Count > 1)
                        {
                            newSubstrings.Add(substring.Skip(1));
                        }
                    }
                    else
                    {
                        newSubstrings.Add(substring);
                    }
                }
                return new PasscodeState(_passcode.Concat(new[] { val }), newSubstrings);
            }

            public IEnumerable<int> GetOrderedNextDigits()
            {
                return _substrings.GroupBy(s => s[0]).OrderByDescending(g => g.Count()).Select(g => g.Key);
            }
        }
    }
}
