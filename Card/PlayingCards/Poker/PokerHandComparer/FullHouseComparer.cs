using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public class FullHouseComparer : PokerRankComparerBase
    {
        protected override PokerHandRank RankToCompare => PokerHandRank.FullHouse;

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            var xGroups = x.ActiveCards.GroupBy(g => g.Rank);
            var xTripletRank = (int)xGroups.Single(g => g.Count() == 3).First().Rank;

            var yGroups = y.ActiveCards.GroupBy(g => g.Rank);
            var yTripletRank = (int)xGroups.Single(g => g.Count() == 3).First().Rank;
            if (xTripletRank != yTripletRank)
            {
                return xTripletRank.CompareTo(yTripletRank);
            }

            var xPairRank = (int)xGroups.Single(g => g.Count() == 2).First().Rank;
            var yPairRank = (int)yGroups.Single(g => g.Count() == 2).First().Rank;

            return xPairRank.CompareTo(yPairRank);
        }
    }
}
