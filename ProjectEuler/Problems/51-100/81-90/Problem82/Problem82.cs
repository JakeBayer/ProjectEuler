using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem82 : IProblem
    {
        private long[,] ParseMatrix()
        {
            var reader = FileHelper.ForProblem(82).OpenFile("matrix.txt");
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
            for (int i = 0; i < size; i++)
            {
                minimumPath[0, i] = matrix[0, i];
            }

            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    minimumPath[i, j] = minimumPath[i - 1, j] + matrix[i, j];
                }
                var updatedAny = true;
                while (updatedAny)
                {
                    updatedAny = false;
                    for (int j = 0; j < size; j++)
                    {
                        if (minimumPath[i, j] > Math.Min(j == 0 ? long.MaxValue : (minimumPath[i, j-1] + matrix[i, j]), j == size - 1 ? long.MaxValue : (minimumPath[i, j+1] + matrix[i, j])))
                        {
                            updatedAny = true;
                            minimumPath[i, j] = Math.Min(j == 0 ? long.MaxValue : (minimumPath[i, j - 1] + matrix[i, j]), j == size - 1 ? long.MaxValue : (minimumPath[i, j + 1] + matrix[i, j]));
                        }
                    }
                }
            }

            var min = long.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if (minimumPath[size - 1, i] < min)
                {
                    min = minimumPath[size - 1, i];
                }
            }

            return min.ToString();
        }
    }
}
