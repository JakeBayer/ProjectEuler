using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
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
