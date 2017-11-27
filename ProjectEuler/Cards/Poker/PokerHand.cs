using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Poker
{
    public class PokerHand : Hand<PokerCard>
    {
        public PokerHandRank Rank { get; private set; }

        public IEnumerable<PokerCard> ActiveCards => Cards.Where(c => c.IsActiveInHand);
        public IEnumerable<PokerCard> PassiveCards => Cards.Where(c => c.IsPassiveInHand);

        public PokerHand(IEnumerable<PokerCard> cards)
            : base(cards)
        {
            EvaluateHand();
        }

        private void EvaluateHand()
        {
            Rank = PokerHandEvaluator.EvaluateHand(this);
        }

        public override void AddCard(PokerCard card)
        {
            base.AddCard(card);
            EvaluateHand();
        }
    }
}
