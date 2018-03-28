using System.Collections.Generic;
using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public class FlushEvlauator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Suit);
            if (groups.Any(g => g.Count() >= 5))
            {
                var flushes = groups.Where(g => g.Count() >= 5);
                var flush = flushes.Where(f => f.Max(c => c.Rank) == flushes.Max(f2 => f2.Max(c => c.Rank))).First();
                foreach (var card in flush)
                {
                    card.IsActiveInHand = true;
                }
                return true;
            }
            return false;
        }
    }
}
