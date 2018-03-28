using System;

namespace Card.Monopoly
{
    public class MonopolyCard : CardBase
    {
        private readonly Func<int, int> _cardInstruction;
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
