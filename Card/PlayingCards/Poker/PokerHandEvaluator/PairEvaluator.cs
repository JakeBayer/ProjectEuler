using System.Collections.Generic;
using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public class PairEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Rank);
            if (groups.Count(g => g.Count() == 2) == 1 && !groups.Any(g => g.Count() > 2))
            {
                var pair = groups.Single(g => g.Count() == 2);
                foreach (var card in pair)
                {
                    card.IsActiveInHand = true;
                }

                var rest = groups.Where(g => g.Count() != 2).Select(c => c.Single()).OrderByDescending(c => c.Rank);
                foreach (var card in rest.Take(3))
                {
                    card.IsPassiveInHand = true;
                }

                return true;
            }
            return false;
        }
    }
}
