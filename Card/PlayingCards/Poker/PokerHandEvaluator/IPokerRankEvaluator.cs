using System.Collections.Generic;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public interface IPokerRankEvaluator
    {
        bool Evaluate(IEnumerable<PokerCard> cards);
    }
}
