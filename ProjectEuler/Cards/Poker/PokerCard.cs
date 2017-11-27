using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class PokerCard : Card
    {
        public PokerCard(Rank rank, Suit suit) : base(rank, suit)
        {
        }

        public PokerCard(Card other) : base(other) { }

        public bool IsActiveInHand { get; set; }
        public bool IsPassiveInHand { get; set; }
    }
}
