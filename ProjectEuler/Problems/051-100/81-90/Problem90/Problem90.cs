using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem90 : IProblem
    {
        private struct Pair
        {
            public int a;
            public int b;
        }

        public class Pair<T>
        {
            public T a { get; set; }
            public T b { get; set; }
        }

        private Pair<int>[] _squares = new[] {
            new Pair<int> { a = 0, b = 1 },
            new Pair<int> { a = 0, b = 4 },
            new Pair<int> { a = 0, b = 6 }, // 6 and 9 are the same (don't ask)
            new Pair<int> { a = 1, b = 6 },
            new Pair<int> { a = 2, b = 5 },
            new Pair<int> { a = 3, b = 6 },
            new Pair<int> { a = 4, b = 6 }, // 6 and 9 are the same (don't ask)
            new Pair<int> { a = 6, b = 4 },
            new Pair<int> { a = 8, b = 1 },
        };

        public string Run()
        {
            CountCubes(1, new HashSet<int> { 0 }, new HashSet<int> { 1 });

            
            var p = 5;
            
            throw new NotImplementedException();
        }

        private List<Pair<HashSet<int>>> cubePairs = new List<Pair<HashSet<int>>>();

        public void CountCubes(int square, HashSet<int> cube1, HashSet<int> cube2)
        {
            if (cube1.Count > 6 || cube2.Count > 6) return;

            if (square == 9)
            {
                cubePairs.Add(new Pair<HashSet<int>> { a = cube1, b = cube2 });
                return;
            }

            var pair = _squares[square];

            var newCube11 = new HashSet<int>(cube1);
            var newCube12 = new HashSet<int>(cube1);

            var newCube21 = new HashSet<int>(cube2);
            var newCube22 = new HashSet<int>(cube2);


            bool anyAdded = false;
            // add a to left, b to right
            if (!newCube11.Contains(pair.a))
            {
                newCube11.Add(pair.a);
                anyAdded = true;
            }
            if (!newCube21.Contains(pair.b))
            {
                newCube21.Add(pair.b);
                anyAdded = true;
            }
            CountCubes(square + 1, newCube11, newCube21);

            // add b to left, c to right
            if (!newCube12.Contains(pair.b))
            {
                newCube12.Add(pair.b);
                anyAdded = true;
            }
            if (!newCube22.Contains(pair.a))
            {
                newCube22.Add(pair.a);
                anyAdded = true;
            }
            if (anyAdded)
            {
                CountCubes(square + 1, newCube12, newCube22);
            }
        }
    }
}
