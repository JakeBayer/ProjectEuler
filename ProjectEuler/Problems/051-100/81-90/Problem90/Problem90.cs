using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem90 : IProblem
    {
        public class Pair<T>
        {
#pragma warning disable IDE1006 // Naming Styles
            public T a { get; set; }
            public T b { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        private class Cube : HashSet<int>
        {
            public Cube(IEnumerable<int> other) : base(other) { }

            public Cube(params int[] other) : base(other) { }
        }

        private class CubeComparer : IEqualityComparer<Pair<Cube>>
        {
            public bool Equals(Pair<Cube> x, Pair<Cube> y)
            {
                return (x.a.SetEquals(y.a) && x.b.SetEquals(y.b)) 
                    || (x.a.SetEquals(y.b) && x.b.SetEquals(y.a));
            }

            public int GetHashCode(Pair<Cube> obj)
            {
                return obj.a.Aggregate(0, (acc, cur) => acc ^ cur) ^ obj.b.Aggregate(0, (acc, cur) => acc ^ cur);
            }
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
            var minimalCubes = GenerateMinimalCubes(1, new Cube { 0 }, new Cube { 1 }).ToList();

            return GenerateUniqueCubePairs(minimalCubes).ToString();
        }

        private long GenerateUniqueCubePairs(IEnumerable<Pair<Cube>> minimalCubes)
        {
            HashSet<Pair<Cube>> cubePairs = new HashSet<Pair<Cube>>(new CubeComparer());
            foreach (var minimalCube in minimalCubes)
            {
                foreach(var pair in FillOutMinimalCubePair(minimalCube))
                {
                    cubePairs.Add(pair);
                }
            }
            return cubePairs.Count();
        }

        private IEnumerable<Pair<Cube>> FillOutMinimalCubePair(Pair<Cube> cubes)
        {
            Cube a = cubes.a,
                b = cubes.b;

            if (a.Count == 6 && b.Count == 6)
            {
                yield return new Pair<Cube> { a = a, b = b };
                Cube tempA = new Cube(a), tempB = new Cube(b);
                if (a.Contains(6) && !a.Contains(9))
                {
                    tempA.Remove(6);
                    tempA.Add(9);
                    yield return new Pair<Cube> { a = tempA, b = b };
                }
                if (b.Contains(6) && !b.Contains(9))
                {
                    tempB.Remove(6);
                    tempB.Add(9);
                    yield return new Pair<Cube> { a = a, b = tempB };
                }
                if (a.Contains(6) && !a.Contains(9) && b.Contains(6) && !b.Contains(9))
                {
                    yield return new Pair<Cube> { a = tempA, b = tempB };
                }
                yield break;
            }

            if (a.Count < 6)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!a.Contains(i))
                    {
                        var tempA = new Cube(a);
                        tempA.Add(i);
                        foreach(var cube in FillOutMinimalCubePair(new Pair<Cube> { a = tempA, b = b }))
                        {
                            yield return cube;
                        }
                    }
                }
            }

            if (b.Count < 6)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!b.Contains(i))
                    {
                        var tempB = new Cube(b);
                        tempB.Add(i);
                        foreach (var cube in FillOutMinimalCubePair(new Pair<Cube> { a = a, b = tempB }))
                        {
                            yield return cube;
                        }
                    }
                }
            }
        }

        //private List<Pair<Cube>> cubePairs = new List<Pair<Cube>>();

        private IEnumerable<Pair<Cube>> GenerateMinimalCubes(int square, Cube cube1, Cube cube2)
        {
            if (cube1.Count > 6 || cube2.Count > 6)
            {
                yield break;
            }

            if (square == 9)
            {
                //cubePairs.Add(new Pair<Cube> { a = cube1, b = cube2 });
                yield return new Pair<Cube> { a = cube1, b = cube2 };
                yield break;
            }

            var pair = _squares[square];

            var newCube11 = new Cube(cube1);
            var newCube12 = new Cube(cube1);

            var newCube21 = new Cube(cube2);
            var newCube22 = new Cube(cube2);


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
            foreach (var cubes in GenerateMinimalCubes(square + 1, newCube11, newCube21))
            {
                yield return cubes;
            }

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
                foreach (var cubes in GenerateMinimalCubes(square + 1, newCube12, newCube22))
                {
                    yield return cubes;
                }
            }
        }
    }
}
