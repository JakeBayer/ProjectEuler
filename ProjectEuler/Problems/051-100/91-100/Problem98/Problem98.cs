using ProjectEuler.Extensions;
using MathUtil.AbstractAlgebra;
using MathUtil.GeometricNumbers;
using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
  public class Problem98 : IProblem
  {
    public string Run()
    {
      var words = ReadWords().OrderBy(s => s.Length).ToList();
      var maxLength = words.Max(s => s.Length);

      var squares = new Square().GenerateWhileLessThan(TenToThe(maxLength));
      var squaresBySize = squares.ToLookup(square => square.ToString().Length);

      var wordsHash = new HashSet<string>(words);

      var wordPermutationPairs = new List<(string word, IEnumerable<Permutation> permutations)>();

      for (int i = 0; i < words.Count - 1; i++)
      {
        var current = words[i];
        int j = 1;
        while (i + j < words.Count && words[i + j].Length == current.Length)
        {
          var next = words[i + j];
          var permutations = Permutation.FromSets(current, next).ToList();
          if (permutations.Any())
          {
            wordPermutationPairs.Add((next, permutations));
            //wordPermutationPairs.Add((next, permutations.Select(permutation => permutation.Inverse())));
          }
          j++;
        }
      }

      long max = 0;

      foreach (var (word, permutations) in wordPermutationPairs)
      {
        foreach (var square in squaresBySize[word.Length])
        {
          if (StringMatchesSquare(word, square))
          {
            foreach (var permutation in permutations)
            {
              var permutedAsString = permutation.ApplyTo(square.ToString());
              if (permutedAsString[0] == '0')
              {
                continue;
              }
              var permuted = long.Parse(permutedAsString);
              if (squares.Contains(permuted))
              {
                max = new long[] { max, permuted, square }.Max();
                // Console.WriteLine("=====================");
                // Console.WriteLine(word);
                // Console.WriteLine(permutation.ApplyTo(word));
                // Console.WriteLine(square);
                // Console.WriteLine(permuted);
                // Console.WriteLine("=====================");
              }
            }
          }
        }
      }

      return max.ToString();
    }

    private bool StringMatchesSquare(string word, long square)
    {
      var digits = square.ToDigits().ToList();
      if (digits.Count != word.Length)
      {
        return false;
      }
      var seen = new HashSet<int>();
      var map = new Dictionary<char, int>();

      for (int i = 0; i < word.Length; i++)
      {
        var ch = word[i];
        var d = digits[i];

        if (!seen.Contains(d))
        {
          if (!map.ContainsKey(ch))
          {
            seen.Add(d);
            map.Add(ch, d);
            continue;
          }
          return false;
        }
        if (!map.ContainsKey(ch))
        {
          return false;
        }
        if (map[ch] != d)
        {
          return false;
        }
      }
      return true;
    }

    private long TenToThe(int n)
    {
      long ans = 1L;
      for (int i = 0; i < n; i++)
      {
        ans *= 10L;
      }

      return ans;
    }

    private IEnumerable<string> ReadWords()
    {
      using (StreamReader reader = FileHelper.ForProblem(98).OpenFile("words.txt"))
      {
        return reader.ReadLine().Split(',').Select(s => s.Trim('\"'));
      }
    }


  }
}
