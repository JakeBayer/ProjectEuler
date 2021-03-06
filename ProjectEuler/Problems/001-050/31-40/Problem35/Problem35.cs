using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using MathUtil.AbstractAlgebra;
using MathUtil.NumberTheory;

namespace ProjectEuler.Problems
{
  public class Problem35 : IProblem
  {
    private const long UP_TO = 1000000;
    public string Run()
    {
      var primes = Prime.Sieve.UpTo<HashSet<long>>(UP_TO);

      HashSet<int> ans = new HashSet<int>(new[] { 2 });
      //List<int> ans = new List<int> { 2 }; // Initialize list with 2 to save small amount of time
      for (int i = 3; i < UP_TO; i += 2)
      {
        if (primes.Contains(i))
        {
          var cycles = i.ToString().Select(c => int.Parse(c.ToString())).AllFullCycles().Select(p => int.Parse(String.Join("", p.Select(c => c.ToString()))));
          if (cycles.All(p => primes.Contains(p)))
          {
            ans.UnionWith(cycles);
          }
        }
      }
      return ans.Count.ToString();
    }
  }
}
