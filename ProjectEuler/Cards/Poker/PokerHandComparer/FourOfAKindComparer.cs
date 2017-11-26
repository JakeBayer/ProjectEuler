using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class FourOfAKindComparer : PokerRankComparerBase
    {
        protected override PokerHandRank rankToCompare => PokerHandRank.FourOfAKind;

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            var activeXRank = (int)x.ActiveCards.First().Rank;
            var activeYRank = (int)y.ActiveCards.First().Rank;
            if (activeXRank != activeYRank)
            {
                return activeYRank.CompareTo(activeYRank);
            }
            var passiveXRank = (int)x.PassiveCards.First().Rank;
            var passiveYRank = (int)y.PassiveCards.First().Rank;
            return passiveXRank.CompareTo(passiveYRank);
        }
    }
}
