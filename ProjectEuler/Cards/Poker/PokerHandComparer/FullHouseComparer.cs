using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class FullHouseComparer : PokerRankComparerBase
    {
        protected override PokerHandRank rankToCompare => PokerHandRank.FullHouse;

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            var xGroups = x.ActiveCards.GroupBy(g => g.Rank);
            var xTripletRank = (int)xGroups.Single(g => g.Count() == 3).First().Rank;

            var yGroups = y.ActiveCards.GroupBy(g => g.Rank);
            var yTripletRank = (int)xGroups.Single(g => g.Count() == 3).First().Rank;
        }
    }
}
