using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class StraightFlushEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Suit);
            if (!groups.Any(g => g.Count() >= 5))
            {
                return false;
            }

            groups = groups.Where(g => g.Count() >= 5);
            var cardsInRankAndSuit = new Dictionary<Suit, List<PokerCard>[]>();
            foreach(var group in groups)
            {
                var cardArray = new List<PokerCard>[14];
                for (int i = 0; i < 14; i++)
                {
                    cardArray[i] = new List<PokerCard>();
                }
                cardsInRankAndSuit.Add(group.Key, cardArray);
            }

            foreach (var card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    cardsInRankAndSuit[card.Suit][0].Add(card);
                    cardsInRankAndSuit[card.Suit][13].Add(card);
                }
                else
                {
                    cardsInRankAndSuit[card.Suit][((int)card.Rank) - 1].Add(card);
                }
            }

            var hasStraightFlush = false;

            Dictionary<Suit, int> runsBySuit = new Dictionary<Suit, int>();
            int curr = 14;
            Suit flushedSuit = Suit.Clubs;
            while (!hasStraightFlush && curr >= 0)
            {
                curr--;
                foreach (var suit in groups.Select(g => g.Key))
                { 
                    if (cardsInRankAndSuit[suit][curr].Any())
                    {
                        runsBySuit[suit]++;
                    }
                    else
                    {
                        runsBySuit[suit] = 0;
                    }
                    if (runsBySuit[suit] == 5)
                    {
                        hasStraightFlush = true;
                        flushedSuit = suit;
                    }
                }
            }
            if (!hasStraightFlush) return hasStraightFlush;
            for (int i = curr; i < curr + 5; i++)
            {
                cardsInRankAndSuit[flushedSuit][i].First().IsActiveInHand = true;
            }
            return true;
        }
    }
}
