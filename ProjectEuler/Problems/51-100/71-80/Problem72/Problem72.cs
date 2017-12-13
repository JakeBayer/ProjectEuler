﻿using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem72 : IProblem
    {
        private const long ONE_MILLION = 1000000;
        public string Run()
        {
            var phi = Totient.UpTo(ONE_MILLION);
            return phi.Skip(2).Sum().ToString();
        }
    }
}
