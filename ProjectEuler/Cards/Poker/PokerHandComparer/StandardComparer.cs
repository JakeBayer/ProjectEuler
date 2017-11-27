using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class StandardComparer : PokerRankComparerBase
    {
        private PokerHandRank _rankToCompare;

        public StandardComparer(PokerHandRank rank)
        {
            _rankToCompare = rank;
        }

        protected override PokerHandRank RankToCompare => _rankToCompare;

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
