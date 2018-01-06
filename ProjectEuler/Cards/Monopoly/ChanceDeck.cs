using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards.Monopoly
{
    public class ChanceDeck : Deck<MonopolyCard>
    {
        private static IEnumerable<MonopolyCard> s_standardChanceDeck = Enumerable.Repeat(new MonopolyCard(i => i), 6)
            .Concat(new[]
            {
                new MonopolyCard(i => 0), // advance to GO
                new MonopolyCard(i => 10), // go to JAIL
                new MonopolyCard(i => 11), // go to C1
                new MonopolyCard(i => 24), // go to E3
                new MonopolyCard(i => 39), // go to H2
                new MonopolyCard(i => 5), // go to R1
                new MonopolyCard(i => (i + (10 - ((i+5)%10))) % 40), // go to next Railroad
                new MonopolyCard(i => (i + (10 - ((i+5)%10))) % 40), // go to next Railroad
                new MonopolyCard(i => (i < 28 && i > 12) ? 28 : 12), // go to next Utility
                new MonopolyCard(i => i - 3), // go back 3 spaces
            });

        public ChanceDeck() : base(s_standardChanceDeck) { }
    }
}
