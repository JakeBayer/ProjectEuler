using ProjectEuler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem91 : IProblem
    {
        public string Run()
        {
            return CountRightTrianglesOnGridOfSize(50, 50).ToString();
        }

        public long CountRightTrianglesOnGridOfSize(int maxX, int maxY)
        {
            /* Start with the trivial right triangles. Trivial right triangles consist of:
                1) triangles where both legs lie on the x and y axes (there are x * y of these)
                2) triangles where one of the legs lies on the x and y axes, and the other vector is the hypotnuse. 
                    It should be obvious that for every point not on either axis (of which there are x * y), there 
                    are two associated right triangles (one for each axis). These are the vectors "projected" onto the axes.
                Therefore there are 3 * x * y trivial right triangles.
            */
            long totalRightTriangles = 3 * maxX * maxY;

            // Now we count the non-trivial triangles. (ones where the right angle does not touch either axis.
            for (int x = 1; x <= maxX; x++)
            {
                for (int y = 1; y <= maxY; y++)
                {
                    totalRightTriangles += CountLeft(x, y, maxX, maxY) + CountRight(x, y, maxX, maxY);
                }
            }

            return totalRightTriangles;
        }

        private int CountLeft(int x, int y, int maxX, int maxY)
        {
            var gcd = x.GCD(y);
            var dx = y / gcd;
            var dy = x / gcd;
            int x2 = x - dx, y2 = y + dy, total = 0;
            while (x2 >= 0 && y2 <= maxY)
            {
                x2 -= dx;
                y2 += dy;
                total++;
            }
            return total;
        }

        private int CountRight(int x, int y, int maxX, int maxY)
        {
            var gcd = x.GCD(y);
            var dx = y / gcd;
            var dy = x / gcd;
            int x2 = x + dx, y2 = y - dy, total = 0;
            while (x2 <= maxX && y2 >= 0)
            {
                x2 += dx;
                y2 -= dy;
                total++;
            }
            return total;
        }
    }
}
