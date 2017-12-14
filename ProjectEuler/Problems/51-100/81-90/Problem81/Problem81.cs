using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem81 : IProblem
    {
        private long[,] ParseMatrix()
        {
            var reader = FileHelper.ForProblem(81).OpenFile("matrix.txt");
            var line = reader.ReadLine();
            var values = line.Split(',');
            long[,] matrix = new long[values.Length, values.Length];
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[0, j] = long.Parse(values[j]);
            }
            int row = 1;
            while (!reader.EndOfStream)
            {
                values = reader.ReadLine().Split(',');
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[row, j] = long.Parse(values[j]);
                }
                row++;
            }
            return matrix;
        }

        public string Run()
        {
            var matrix = ParseMatrix();
            var minimumPath = new long[matrix.GetLength(0), matrix.GetLength(0)];
            minimumPath[0, 0] = matrix[0, 0];
            var size = matrix.GetLength(0);
            //First diagonal
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    minimumPath[i - j, j] = matrix[i - j, j] + Math.Min(j == 0 ? long.MaxValue : minimumPath[i - j, j - 1], i - j == 0 ? long.MaxValue : minimumPath[i - j - 1, j]);
                }
            }

            //Second diagonal
            for (int i = size - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    minimumPath[size - j - 1, size - i + j - 1] = matrix[size - j - 1, size - i + j - 1] + Math.Min(minimumPath[size - j - 2, size - i + j - 1], minimumPath[size - j - 1, size - i + j - 2]);
                }
            }

            return minimumPath[size - 1, size - 1].ToString();
        }
    }
}
