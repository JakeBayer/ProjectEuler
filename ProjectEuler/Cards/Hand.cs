using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public class Hand
    {
        public Hand() { }
        public Hand(IEnumerable<Card> cards)
        {
            Cards = new List<Card>(cards);
        }
        List<Card> Cards { get; }

        public virtual void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
