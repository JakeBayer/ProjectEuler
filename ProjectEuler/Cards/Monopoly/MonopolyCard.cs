using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Monopoly
{
    public class MonopolyCard : CardBase
    {
        private Func<int, int> _cardInstruction;
        public MonopolyCard(Func<int, int> instruction)
        {
            _cardInstruction = instruction;
        }

        public int FollowInstruction(int currentPlace)
        {
            return _cardInstruction(currentPlace);
        }
    }
}
