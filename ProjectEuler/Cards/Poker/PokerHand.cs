using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class PokerHand : Hand
    {
        public HandRank Rank { get; private set; }

        private List<Card> ActiveCards;
        private List<Card> PassiveCards;

        public PokerHand(IEnumerable<Card> cards)
            : base(cards)
        {
            ActiveCards = new List<Card>();
            PassiveCards = new List<Card>();
            EvaluateHand();
        }

        private void EvaluateHand()
        {
            throw new NotImplementedException();
        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);
            EvaluateHand();
        }
    }
}
