using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
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
