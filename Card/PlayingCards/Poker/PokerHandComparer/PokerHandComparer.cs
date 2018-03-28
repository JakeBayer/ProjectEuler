using System.Collections.Generic;

namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public class PokerHandComparer : IComparer<PokerHand>
    {
        private static readonly Dictionary<PokerHandRank, IComparer<PokerHand>> s_rankComparers = new Dictionary<PokerHandRank, IComparer<PokerHand>>
        {
            [PokerHandRank.StraightFlush] = new StraightFlushComparer(),
            [PokerHandRank.FourOfAKind] = new StandardComparer(PokerHandRank.FourOfAKind),
            [PokerHandRank.FullHouse] = new FullHouseComparer(),
            [PokerHandRank.Flush] = new StandardComparer(PokerHandRank.Flush),
            [PokerHandRank.Straight] = new StraightComparer(),
            [PokerHandRank.ThreeOfAKind] = new StandardComparer(PokerHandRank.ThreeOfAKind),
            [PokerHandRank.TwoPair] = new StandardComparer(PokerHandRank.TwoPair),
            [PokerHandRank.Pair] = new StandardComparer(PokerHandRank.Pair),
            [PokerHandRank.HighCard] = new StandardComparer(PokerHandRank.HighCard),
        };

        public int Compare(PokerHand x, PokerHand y)
        {
            if (x.Rank != y.Rank)
            {
                return ((int)x.Rank).CompareTo((int)y.Rank);
            }
            return s_rankComparers[x.Rank].Compare(x, y);
        }
    }
}
