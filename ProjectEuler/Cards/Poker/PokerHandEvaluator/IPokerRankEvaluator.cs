using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public interface IPokerRankEvaluator
    {
        bool Evaluate(IEnumerable<PokerCard> cards);
    }
}
