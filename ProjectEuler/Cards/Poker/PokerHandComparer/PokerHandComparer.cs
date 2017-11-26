using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class PokerHandComparer : IComparer<PokerHand>
    {
        private static readonly Dictionary<PokerHandRank, IComparer<PokerHand>> s_rankComparers = new Dictionary<PokerHandRank, IComparer<PokerHand>>
        {
            []
        }
        public int Compare(PokerHand x, PokerHand y)
        {
            throw new NotImplementedException();
        }
    }
}
