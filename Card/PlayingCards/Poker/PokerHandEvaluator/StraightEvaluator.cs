using System.Collections.Generic;
using System.Linq;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public class StraightEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            if (cards.Count() < 5)
            {
                return false;
            }
            var cardsInRank = new List<PokerCard>[14];
            for (int i = 0; i < 14; i++)
            {
                cardsInRank[i] = new List<PokerCard>();
            }
            foreach(var card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    cardsInRank[0].Add(card);
                    cardsInRank[13].Add(card);
                }
                else
                {
                    cardsInRank[((int)card.Rank) - 1].Add(card);
                }
            }

            var hasStraight = false;
            int run = 0, curr = 14;
            while (!hasStraight && curr > 0)
            {
                curr--;
                if (cardsInRank[curr].Any())
                {
                    run++;
                }
                else
                {
                    run = 0;
                }
                if (run == 5)
                {
                    hasStraight = true;
                }
            }
            if (!hasStraight) return false;
            for (int i = curr; i < curr + 5; i++)
            {
                cardsInRank[i].First().IsActiveInHand = true;
            }
            return true;
        } 
    }
}
