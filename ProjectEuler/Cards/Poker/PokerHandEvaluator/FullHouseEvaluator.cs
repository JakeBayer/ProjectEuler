using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class FullHouseEvaluator : IPokerRankEvaluator
    {
        public bool Evaluate(IEnumerable<PokerCard> cards)
        {
            var groups = cards.GroupBy(c => c.Rank);
            if (groups.Any(g => g.Count() == 3) && groups.Count(g => g.Count() >= 2) >= 2 && !groups.Any(g => g.Count() >= 4))
            {
                var triplet = groups.Where(g => g.Count() == 3).OrderByDescending(t => t.Key).First();
                var pair = groups.Where(g => g.Count() >= 2 && g.Key != triplet.Key).OrderByDescending(p => p.Key).First();
                foreach(var card in triplet.Concat(pair))
                {
                    card.IsActiveInHand = true;
                }
                return true;
            }
            return false;
        }
    }
}
