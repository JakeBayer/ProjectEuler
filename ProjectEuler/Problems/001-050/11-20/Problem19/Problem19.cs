using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem19 : IProblem
    {
        public string Run()
        {
            DateTime currentDate = new DateTime(1901, 1, 1);
            int total = 0;
            while(currentDate.Year < 2001)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Day == 1)
                {
                    total++;
                }
                currentDate = currentDate.AddMonths(1);
            }
            return total.ToString();
        }
    }
}
