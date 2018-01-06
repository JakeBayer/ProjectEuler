using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class TwoPairEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Rank);
            if (groups.Count(g => g.Count() == 2) >= 2 && !groups.Any(g => g.Count() > 2))
            {
                var pairs = groups.Where(g => g.Count() == 2).OrderByDescending(g => g.Key).Take(2);
                foreach (var pair in pairs)
                {
                    foreach (var card in pair)
                    {
                        card.IsActiveInHand = true;
                    }
                }
                var rest = cards.Where(c => !pairs.Select(p => p.Key).ToList().Contains(c.Rank)).OrderByDescending(c => c.Rank);
                foreach (var card in rest.Take(1))
                {
                    card.IsPassiveInHand = true;
                }
                return true;
            }
            return false;
        }
    }
}
