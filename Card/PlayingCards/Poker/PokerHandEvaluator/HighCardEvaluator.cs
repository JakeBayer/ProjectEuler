using System.Collections.Generic;
using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public class HighCardEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            cards = cards.OrderByDescending(c => (int)c.Rank);
            cards.ElementAt(0).IsActiveInHand = true;
            foreach (var card in cards.Skip(1).Take(4))
            {
                card.IsPassiveInHand = true;
            }
            return true;
        }
    }
}
