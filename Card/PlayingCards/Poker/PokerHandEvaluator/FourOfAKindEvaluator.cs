using System.Collections.Generic;
using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public class FourOfAKindEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Rank);
            if (groups.Any(g => g.Count() >= 4))
            {
                var quadruplet = groups.Where(g => g.Count() >= 4).OrderByDescending(g => g.Key).First();
                foreach (var card in quadruplet)
                {
                    card.IsActiveInHand = true;
                }
                cards.Where(c => c.Rank != quadruplet.Key).OrderByDescending(c => c.Rank).First().IsPassiveInHand = true;
                return true;
            }
            return false;
        }
    }
}
