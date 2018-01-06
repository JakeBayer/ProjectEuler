using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public class Hand<T> where T : CardBase
    {
        public Hand() { }
        public Hand(IEnumerable<T> cards)
        {
            Cards = new List<T>(cards);
        }
        public List<T> Cards { get; }

        public virtual void AddCard(T card)
        {
            Cards.Add(card);
        }

        public virtual bool RemoveCard(T card)
        {
            return Cards.Remove(card);
        }
    }
}
