using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public class StraightComparer : PokerRankComparerBase
    {
        protected override PokerHandRank RankToCompare => PokerHandRank.Straight;

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            var maxX = x.ActiveCards.Select(c => (int)c.Rank).Max();
            var maxY = y.ActiveCards.Select(c => (int)c.Rank).Max();
            if (maxX == (int)Rank.Ace && x.ActiveCards.Any(c => c.Rank == Rank.Two))
            {
                maxX = 5;
            }
            if (maxY == (int)Rank.Ace && y.ActiveCards.Any(c => c.Rank == Rank.Two))
            {
                maxY = 5;
            }
            return maxX.CompareTo(maxY);
        }
    }
}
