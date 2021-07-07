using System;
using System.Collections.Generic;
using System.Linq;

namespace MathUtil.AbstractAlgebra
{
  public class Permutor<T> where T : IComparable<T>
  {
    private readonly List<T> _set;

    public Permutor(IEnumerable<T> set)
    {
      _set = set.ToList();
    }

    public List<T> PermutationAt(long i)
    {
      var set = new List<T>(_set.OrderBy(e => e).ToList());
      for (long j = 0; j < i - 1; j++)
      {
        NextPermutation(set);
      }
      return set;
    }

    public List<T> NextPermutation()
    {
      NextPermutation(_set);
      return _set;
    }

    public bool NextPermutation(List<T> set)
    {
      // Find non-increasing suffix
      int i = set.Count - 1;
      while (i > 0 && set[i - 1].CompareTo(set[i]) >= 0)
        i--;
      if (i <= 0)
        return false;

      // Find successor to pivot
      int j = set.Count - 1;
      while (set[j].CompareTo(set[i - 1]) <= 0)
        j--;
      T temp = set[i - 1];
      set[i - 1] = set[j];
      set[j] = temp;

      // Reverse suffix
      j = set.Count - 1;
      while (i < j)
      {
        temp = set[i];
        set[i] = set[j];
        set[j] = temp;
        i++;
        j--;
      }
      return true;
    }
  }

  public class Permutation
  {
    public class Sigma
    {
      private int[] _sigma;

      private int _size;

      public Sigma(IEnumerable<int> sigma)
      {
        _sigma = sigma.ToArray();
        if (IsValid(_sigma))
        {
          _size = _sigma.Count();
          return;
        }
        throw new Exception($"{nameof(sigma)} is not a valid sigma function.");
      }

      private bool IsValid(int[] sigma)
      {
        int length = sigma.Count();
        bool[] present = new bool[length];
        foreach (var i in sigma)
        {
          if (i < 1 || i > length)
          {
            return false;
          }
          if (present[i - 1])
          {
            return false;
          }
          present[i - 1] = true;
        }
        return true;
      }

      public int Size => _size;

      public int Of(int index)
      {
        return _sigma[index - 1];
      }
    }

    private List<List<int>> _cycles;
    public Permutation(IEnumerable<IEnumerable<int>> cycles)
    {
      _cycles = cycles.Select(c => c.ToList()).ToList();
    }

    public static Permutation FromSigma(Sigma sigma)
    {
      List<List<int>> cycles = new List<List<int>>();
      var visited = new HashSet<int>();

      for (int i = 1; i <= sigma.Size; i++)
      {
        if (visited.Contains(i))
        {
          continue;
        }
        var cycle = new List<int>();
        var curr = i;
        while (!visited.Contains(curr))
        {
          cycle.Add(curr);
          visited.Add(curr);
          curr = sigma.Of(curr);
        }
        if (cycle.Count > 1)
        {
          cycles.Add(cycle);
        }
      }

      return new Permutation(cycles);
    }

    public Permutation Inverse()
    {
      return new Permutation(_cycles.Reverse<List<int>>().Select(cycle => cycle.Reverse<int>()));
    }

    public static IEnumerable<Permutation> FromSets(string first, string other)
    {
      return FromSets(first.ToList(), other.ToList());
    }

    public static IEnumerable<Permutation> FromSets<T>(IList<T> set, IList<T> other)
    {
      if (!set.IsPermutationOf(other))
      {
        return Enumerable.Empty<Permutation>();
      }

      var elementsByPosition = other.Select((element, index) => (element, index))
        .ToLookup(pair => pair.element, pair => pair.index)
        .ToDictionary(pair => pair.Key, pair => new HashSet<int>(pair));

      IEnumerable<Sigma> getAllPossibleSigmas(Stack<int> sigmaSoFar)
      {
        if (sigmaSoFar.Count == set.Count)
        {
          yield return new Sigma(sigmaSoFar.Reverse());
          yield break;
        }
        var curr = set[sigmaSoFar.Count];
        foreach (var index in new List<int>(elementsByPosition[curr]))
        {
          elementsByPosition[curr].Remove(index);
          sigmaSoFar.Push(index + 1);
          foreach (var sigma in getAllPossibleSigmas(sigmaSoFar))
          {
            yield return sigma;
          }
          elementsByPosition[curr].Add(index);
          sigmaSoFar.Pop();
        }
      }

      return getAllPossibleSigmas(new Stack<int>()).Select(FromSigma);
    }

    public string ApplyTo(string set)
    {
      return new string(ApplyToInternal(set.ToList()).ToArray());
    }

    public IList<T> ApplyTo<T>(IList<T> set)
    {
      return ApplyToInternal(new List<T>(set));
    }

    private IList<T> ApplyToInternal<T>(IList<T> set)
    {
      foreach (var cycle in _cycles)
      {
        var first = set[cycle[0] - 1];
        int i = 1;
        while (i < cycle.Count)
        {
          // All indices need 1 subtracted because cycles are 1-indexed, not 0-indexed
          set[cycle[i - 1] - 1] = set[cycle[i] - 1];
          i++;
        }
        set[cycle[i - 1] - 1] = first;
      }
      return set;
    }
  }

  public static class PermutationExtensions
  {
    public static IEnumerable<List<T>> AllPermutations<T>(this IEnumerable<T> seed)
    {
      var set = new List<T>(seed);
      return Permute(set, 0, set.Count - 1);
    }

    public static IEnumerable<List<T>> PermutationsOfSize<T>(this IEnumerable<T> seed, int size)
    {
      if (seed.Count() < size)
      {
        return new List<List<T>>();
      }
      return seed.PermutationsOfSize(new List<T>(), size);
    }

    private static IEnumerable<List<T>> PermutationsOfSize<T>(this IEnumerable<T> seed, List<T> set, int size)
    {
      if (size == 0)
      {
        foreach (var permutation in set.AllPermutations())
        {
          yield return permutation;
        }
      }
      else
      {
        var seedAsList = seed.ToList();
        for (int i = 0; i < seedAsList.Count; i++)
        {
          var newSet = new List<T>(set) { seedAsList[i] };
          foreach (var permutation in seedAsList.Skip(i + 1).PermutationsOfSize(newSet, size - 1))
          {
            yield return permutation;
          }
        }
      }
    }

    private static IEnumerable<List<T>> Permute<T>(List<T> set, int start, int end)
    {
      if (start == end)
      {
        yield return new List<T>(set);
      }
      else
      {
        for (int i = start; i <= end; i++)
        {
          Swap(set, start, i);
          foreach (var v in Permute(set, start + 1, end))
          {
            yield return v;
          }
          Swap(set, start, i);
        }
      }
    }

    private static void Swap<T>(List<T> set, int a, int b)
    {
      var temp = set[a];
      set[a] = set[b];
      set[b] = temp;
    }

    public static IEnumerable<List<T>> AllFullCycles<T>(this IEnumerable<T> seed)
    {
      var set = new LinkedList<T>(seed);
      for (int i = 0; i < set.Count; i++)
      {
        yield return new List<T>(set);
        var top = set.First();
        set.RemoveFirst();
        set.AddLast(top);
      }
    }

    public static bool IsPermutationOf<T>(this IEnumerable<T> set, IEnumerable<T> other)
    {
      if (set.Count() != other.Count())
      {
        return false;
      }
      var elementCounts = new Dictionary<T, int>();
      foreach (var element in set)
      {
        if (!elementCounts.ContainsKey(element))
        {
          elementCounts.Add(element, 0);
        }
        elementCounts[element]++;
      }

      foreach (var element in other)
      {
        if (!elementCounts.ContainsKey(element))
        {
          return false;
        }

        elementCounts[element]--;
        if (elementCounts[element] == 0)
        {
          elementCounts.Remove(element);
        }
      }
      return true;
    }

    public static bool IsPermutationOf(this long a, long other)
    {
      int[] digits = new int[10];
      while (a > 0)
      {
        digits[a % 10]++;
        a /= 10;
      }
      while (other > 0)
      {
        var digit = other % 10;
        if (digits[digit]-- == 0)
        {
          return false;
        }
        other /= 10;
      }
      for (var i = 0; i < 10; i++)
      {
        if (digits[i] > 0)
        {
          return false;
        }
      }
      return true;
    }

    public static bool IsPermutationOf(this int a, int other)
    {
      int[] digits = new int[10];
      while (a > 0)
      {
        digits[a % 10]++;
        a /= 10;
      }
      while (other > 0)
      {
        var digit = other % 10;
        if (digits[digit]-- == 0)
        {
          return false;
        }
        other /= 10;
      }
      for (var i = 0; i < 10; i++)
      {
        if (digits[i] > 0)
        {
          return false;
        }
      }
      return true;
    }
  }
}
