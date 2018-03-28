using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public class StandardComparer : PokerRankComparerBase
    {
        public StandardComparer(PokerHandRank rank)
        {
            RankToCompare = rank;
        }

        protected override PokerHandRank RankToCompare { get; }

        protected override int CompareValidated(PokerHand x, PokerHand y)
        {
            var orderedX = x.ActiveCards.Select(c => (int)c.Rank).OrderByDescending(r => r).Concat(x.PassiveCards.Select(c => (int)c.Rank).OrderByDescending(r => r)).ToList();
            var orderedY = y.ActiveCards.Select(c => (int)c.Rank).OrderByDescending(r => r).Concat(y.PassiveCards.Select(c => (int)c.Rank).OrderByDescending(r => r)).ToList();
            for (int i = 0; i < orderedX.Count; i++)
            {
                if (orderedX[i] != orderedY[i])
                {
                    return orderedX[i].CompareTo(orderedY[i]);
                }
            }
            return 0;
        }
    }
}
