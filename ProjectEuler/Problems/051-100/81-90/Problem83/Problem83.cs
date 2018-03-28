using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem83 : IProblem
    {
        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private long[,] ParseMatrix()
        {
            var reader = FileHelper.ForProblem(83).OpenFile("matrix.txt");
            var line = reader.ReadLine();
            var values = line.Split(',');
            long[,] matrix = new long[values.Length, values.Length];
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[j, 0] = long.Parse(values[j]);
            }
            int row = 1;
            while (!reader.EndOfStream)
            {
                values = reader.ReadLine().Split(',');
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[j, row] = long.Parse(values[j]);
                }
                row++;
            }
            return matrix;
        }

        public string Run()
        {
            var matrix = ParseMatrix();
            var size = matrix.GetLength(0);
            var minimumPath = new long[size, size];
            minimumPath[0, 0] = matrix[0, 0];
            //First diagonal
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    minimumPath[j, i - j] = matrix[j, i - j] + Math.Min(j == 0 ? long.MaxValue : minimumPath[j - 1, i - j], i - j == 0 ? long.MaxValue : minimumPath[j, i - j - 1]);
                }
            }

            //Second diagonal
            for (int i = size - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    minimumPath[size - i + j - 1, size - j - 1] = matrix[size - i + j - 1, size - j - 1] + Math.Min(minimumPath[size - i + j - 1, size - j - 2], minimumPath[size - i + j - 2, size - j - 1]);
                }
            }

            Queue<Point> updatedPoints = new Queue<Point>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var potentialNewValues = new long[] {
                        j == 0 ? long.MaxValue : (minimumPath[i, j - 1] + matrix[i, j]),
                        i == 0 ? long.MaxValue : (minimumPath[i - 1, j] + matrix[i, j]),
                        j == size - 1 ? long.MaxValue : (minimumPath[i, j + 1] + matrix[i, j]),
                        i == size - 1 ? long.MaxValue : (minimumPath[i + 1, j] + matrix[i, j])
                    };
                    if (minimumPath[i, j] > potentialNewValues.Min())
                    {
                        updatedPoints.Enqueue(new Point(i, j));
                        minimumPath[i, j] = potentialNewValues.Min();
                    }
                }
            }

            while (updatedPoints.Any())
            {
                var point = updatedPoints.Dequeue();
                //left
                if (point.X != 0)
                {
                    if (minimumPath[point.X - 1, point.Y] > matrix[point.X - 1, point.Y] + minimumPath[point.X, point.Y])
                    {
                        updatedPoints.Enqueue(new Point(point.X - 1, point.Y));
                        minimumPath[point.X - 1, point.Y] = matrix[point.X - 1, point.Y] + minimumPath[point.X, point.Y];
                    }
                }
                //up
                if (point.Y != 0)
                {
                    if (minimumPath[point.X, point.Y - 1] > matrix[point.X, point.Y - 1] + minimumPath[point.X, point.Y])
                    {
                        updatedPoints.Enqueue(new Point(point.X, point.Y - 1));
                        minimumPath[point.X, point.Y - 1] = matrix[point.X, point.Y - 1] + minimumPath[point.X, point.Y];
                    }
                }
                //right
                if (point.X != size - 1)
                {
                    if (minimumPath[point.X + 1, point.Y] > matrix[point.X + 1, point.Y] + minimumPath[point.X, point.Y])
                    {
                        updatedPoints.Enqueue(new Point(point.X + 1, point.Y));
                        minimumPath[point.X + 1, point.Y] = matrix[point.X + 1, point.Y] + minimumPath[point.X, point.Y];
                    }
                }
                //down
                if (point.Y != size - 1)
                {
                    if (minimumPath[point.X, point.Y + 1] > matrix[point.X, point.Y + 1] + minimumPath[point.X, point.Y])
                    {
                        updatedPoints.Enqueue(new Point(point.X, point.Y + 1));
                        minimumPath[point.X, point.Y + 1] = matrix[point.X, point.Y + 1] + minimumPath[point.X, point.Y];
                    }
                }
            }

            return minimumPath[size - 1, size - 1].ToString();
        }
    }
}
