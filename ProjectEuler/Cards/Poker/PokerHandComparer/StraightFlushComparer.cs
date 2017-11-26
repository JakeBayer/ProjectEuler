using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class StraightFlushComparer : PokerRankComparerBase
    {
        protected override PokerHandRank rankToCompare => PokerHandRank.StraightFlush;

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            return x.ActiveCards.Max(c => (int)c.Rank).CompareTo(y.ActiveCards.Max(c => (int)c.Rank));
        }
    }
}
