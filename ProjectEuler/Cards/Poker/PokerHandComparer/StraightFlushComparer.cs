using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class StraightFlushComparer : StraightComparer
    {
        protected override PokerHandRank RankToCompare => PokerHandRank.StraightFlush;
    }
}
