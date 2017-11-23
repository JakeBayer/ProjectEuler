using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class GeometricNumber : GeometricNumberBase
    {
        private int _base;
        public GeometricNumber(int n)
        {
            _base = n;
        }
        protected override int baseVal => _base;

        protected override long ExplicitFormula(long n)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class GeometricNumberBase
    {
        protected abstract int baseVal {get;}
        protected abstract long ExplicitFormula(long n);

        protected virtual long ImplicitDifferenceFunction(long n)
        {
            return (baseVal - 1) * n - (baseVal - 2);
        }

        private static GeometricNumberGenerator _generator;

        public GeometricNumberBase()
        {
            _generator = new GeometricNumberGenerator(ImplicitDifferenceFunction, ExplicitFormula);
        }

        public static bool Is(int n) => Is(Convert.ToInt64(n));

        public static bool Is(long n) => _generator.Is(n);

        public HashSet<long> Numbers => _generator._numbers;

        public HashSet<long> GenerateUpTo(long n) => _generator.GenerateUpTo(n);

        public static long Explicit(long n)
        {
            return _generator.Explicit(n);
        }

        private class GeometricNumberGenerator
        {
            private long _max = 0, _curr = 0;
            public HashSet<long> _numbers = new HashSet<long> { 0 };
            private Func<long, long> _diffGenerator;
            private Func<long, long> _explicitGenerator;

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
