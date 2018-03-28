using ProjectEuler.Utils;
using System.Collections.Generic;
using System.Linq;
using MathUtil.GeometricNumbers;

namespace ProjectEuler.Problems
{
    public class Problem61 : IProblem
    {
        private const long TEN_THOUSAND = 10000;

        private readonly Dictionary<string, Dictionary<int, HashSet<long>>> frontTwoToBaseToNumber = new Dictionary<string, Dictionary<int, HashSet<long>>>();
        private readonly Dictionary<string, Dictionary<int, HashSet<long>>> backTwoToBaseToNumber = new Dictionary<string, Dictionary<int, HashSet<long>>>();

        private readonly List<List<long>> _cycles = new List<List<long>>();

        private void InitializeMap()
        {
            for (int i = 3; i <= 8; i++)
            {
                var geometricNumbers = new GeometricNumber(i).GenerateWhileLessThan(TEN_THOUSAND);
                foreach (var number in geometricNumbers.Where(g => g > 1000))
                {
                    var str = number.ToString();
                    string frontTwo = str.Substring(0, 2), backTwo = str.Substring(2, 2);
                    if (!frontTwoToBaseToNumber.ContainsKey(frontTwo))
                    {
                        frontTwoToBaseToNumber.Add(frontTwo, new Dictionary<int, HashSet<long>>());
                    }
                    if (!frontTwoToBaseToNumber[frontTwo].ContainsKey(i))
                    {
                        frontTwoToBaseToNumber[frontTwo].Add(i, new HashSet<long>());
                    }
                    frontTwoToBaseToNumber[frontTwo][i].Add(number);
                    if (!backTwoToBaseToNumber.ContainsKey(backTwo))
                    {
                        backTwoToBaseToNumber.Add(backTwo,new Dictionary<int, HashSet<long>>());
                    }
                    if (!backTwoToBaseToNumber[backTwo].ContainsKey(i))
                    {
                        backTwoToBaseToNumber[backTwo].Add(i, new HashSet<long>());
                    }
                    backTwoToBaseToNumber[backTwo][i].Add(number);
                }
            }
        }

        public string FrontTwo(long number)
        {
            return number.ToString().Substring(0, 2);
        }

        public string BackTwo(long number)
        {
            return number.ToString().Substring(2, 2);
        }

        public void CycleSearch(List<long> numbersUsed, HashSet<int> basesRemaining)
        {
            var lastNumber = numbersUsed.Last();
            var backTwo = BackTwo(lastNumber);
            if (!frontTwoToBaseToNumber.ContainsKey(backTwo)) return;
            if (basesRemaining.Count == 1)
            {
                var baseNumber = basesRemaining.Single();
                if (!frontTwoToBaseToNumber[backTwo].ContainsKey(baseNumber)) return;
                if (frontTwoToBaseToNumber[backTwo][baseNumber].Contains(long.Parse(backTwo + FrontTwo(numbersUsed.First()))))
                {
                    numbersUsed.Add(long.Parse(backTwo + FrontTwo(numbersUsed.First())));
                    _cycles.Add(new List<long>(numbersUsed));
                }
                return;
            }
            else
            {
                foreach (var remainingBase in basesRemaining.Where(b => frontTwoToBaseToNumber[backTwo].ContainsKey(b)))
                {
                    foreach(var number in frontTwoToBaseToNumber[backTwo][remainingBase])
                    {
                        CycleSearch(new List<long>(numbersUsed.Concat(new[] { number })), new HashSet<int>(basesRemaining.Except(new[] { remainingBase })));
                    }
                }
            }
        }

        public string Run()
        {
            InitializeMap();
            var remainingBases = new HashSet<int> { 3, 4, 5, 6, 7 };
            foreach (var octad in new GeometricNumber(8).GenerateWhileLessThan(TEN_THOUSAND).Where(g => g > 1000))
            {
                CycleSearch(new List<long> { octad }, remainingBases);
            }

            return _cycles.First().Sum().ToString();
        }
    }
}
