namespace ProjectEuler.Problems
{
    public class Problem28 : IProblem
    {
        private int[,] GenerateSpiral(int size)
        {
            var spiral = new int[size, size];
            int count = 1;
            int row = size / 2, col = size / 2;
            for (int i = 0; i <= size / 2 - 1; i++)
            {
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    spiral[row, col] = count;
                    count++;
                    col++;
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    spiral[row, col] = count;
                    count++;
                    row++;
                }
                for (int j = 0; j < 2 * i + 2; j++)
                {
                    spiral[row, col] = count;
                    count++;
                    col--;
                }
                for (int j = 0; j < 2 * i + 2; j++)
                {
                    spiral[row, col] = count;
                    count++;
                    row--;
                }
            }
            for (int j = 0; j < size; j++)
            {
                spiral[row, col] = count;
                count++;
                col++;
            }


            return spiral;
        }

        private long SumDiagonal(int[,] spiral)
        {
            var size = spiral.GetLength(0);
            long total = 0;
            for (int j = 0; j < size; j++)
            {
                total += spiral[j, j] + spiral[size - j - 1, j];
            }
            return total - 1;
        }

        public string Run()
        {
            var spiral = GenerateSpiral(1001);
            //var spiral = GenerateSpiral(5);

            return SumDiagonal(spiral).ToString();
        }
    }
}
