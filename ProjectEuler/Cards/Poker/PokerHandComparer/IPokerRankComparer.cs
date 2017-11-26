using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public abstract class PokerRankComparerBase : IComparer<PokerHand>
    {
        protected abstract PokerHandRank rankToCompare { get; }
        public int Compare(PokerHand x, PokerHand y)
        {
            if (x.Rank != rankToCompare || y.Rank != rankToCompare)
            {
                throw new InvalidOperationException($"One of these hands is not of the correct rank. I can only compare two {rankToCompare}")
            }
            return CompareValidated(x, y);
        }

        protected abstract int CompareValidated(PokerHand x, PokerHand y);
    }
}
