using System.Collections.Generic;
using System.Linq;

namespace Card.Monopoly
{
    public class CommunityChestDeck : Deck<MonopolyCard>
    {
        private static readonly IEnumerable<MonopolyCard> s_standardCommunityChestDeck = Enumerable.Repeat(new MonopolyCard(i => i), 14)
            .Concat(new[]
            {
                new MonopolyCard(i => 0), // advance to GO
                new MonopolyCard(i => 10) // go to JAIL
            });

        public CommunityChestDeck() : base(s_standardCommunityChestDeck) { }
    }
}
