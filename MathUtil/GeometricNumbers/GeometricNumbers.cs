using System;
using System.Collections.Generic;

namespace MathUtil.GeometricNumbers
{
    public class GeometricNumber : GeometricNumberBase
    {
        public GeometricNumber(int n)
        {
            baseVal = n;
        }
        protected override int baseVal { get; }

        protected override long ExplicitFormula(long n)
        {
            return n * ((baseVal - 2) * n - (baseVal - 4))/2;
        }
    }

    public abstract class GeometricNumberBase
    {
        protected abstract int baseVal {get;}
        protected abstract long ExplicitFormula(long n);

        protected virtual long ImplicitDifferenceFunction(long n)
        {
            return (baseVal - 2) * n - (baseVal - 3);
        }

        private readonly GeometricNumberGenerator _generator;

        protected GeometricNumberBase()
        {
            _generator = new GeometricNumberGenerator(ImplicitDifferenceFunction, ExplicitFormula);
        }

        public bool Is(int n) => Is(Convert.ToInt64(n));

        public bool Is(long n) => _generator.Is(n);

        public HashSet<long> Numbers => _generator._numbers;

        public HashSet<long> GenerateUpTo(long n) => _generator.GenerateUpTo(n);

        public HashSet<long> GenerateWhileLessThan(long n) => _generator.GenerateWhileLessThan(n);

        public long Explicit(long n)
        {
            return _generator.Explicit(n);
        }

        private class GeometricNumberGenerator
        {
            private long _max = 0, _curr = 0;
            public readonly HashSet<long> _numbers = new HashSet<long> { 0 };
            private readonly Func<long, long> _diffGenerator;
            private readonly Func<long, long> _explicitGenerator;

            public GeometricNumberGenerator(Func<long, long> implicitDiffGenerator, Func<long, long> explicitGenerator)
            {
                _diffGenerator = implicitDiffGenerator;
                _explicitGenerator = explicitGenerator;
            }

            public HashSet<long> GenerateUpTo(long n)
            {
                while (_curr <= n)
                {
                    _curr++;
                    _max += _diffGenerator(_curr);
                    _numbers.Add(_max);
                }
                return _numbers;
            }

            public HashSet<long> GenerateWhileLessThan(long n)
            {
                while (_max < n)
                {
                    _curr++;
                    _max += _diffGenerator(_curr);
                    _numbers.Add(_max);
                }
                return _numbers;
            }

            public bool Is(int n)
            {
                return Is(Convert.ToInt64(n));
            }

            public bool Is(long n)
            {
                if (n > _max)
                {
                    while (n >= _max)
                    {
                        _curr++;
                        _max += _diffGenerator(_curr);
                        _numbers.Add(_max);
                    }
                }
                return _numbers.Contains(n);
            }

            public long Explicit(long n) => _explicitGenerator(n);
        }
    }
}
