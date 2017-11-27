using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class ThreeOfAKindEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Rank);
            if (groups.Count(g => g.Count() == 3) == 1 && !groups.Any(g => g.Count() == 2) && !groups.Any(g => g.Count() > 3))
            {
                var triplet = groups.Single(g => g.Count() == 3);
                foreach (var card in triplet)
                {
                    card.IsActiveInHand = true;
                }
                var rest = cards.Where(c => c.Rank != triplet.Key).OrderByDescending(c => c.Rank);
                foreach (var card in rest.Take(2))
                {
                    card.IsPassiveInHand = true;
                }
                return true;
            }
            return false;
        }
    }
}
