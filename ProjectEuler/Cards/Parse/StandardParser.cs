using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public class StandardParser : ICardParser
    {
        private static readonly Dictionary<char, Rank> s_charToCardRank = new Dictionary<char, Rank>
        {
            ['A'] = Rank.Ace,
            ['2'] = Rank.Two,
            ['3'] = Rank.Three,
            ['4'] = Rank.Four,
            ['5'] = Rank.Five,
            ['6'] = Rank.Six,
            ['7'] = Rank.Seven,
            ['8'] = Rank.Eight,
            ['9'] = Rank.Nine,
            ['T'] = Rank.Ten,
            ['J'] = Rank.Jack,
            ['Q'] = Rank.Queen,
            ['K'] = Rank.King,
        };

        private static readonly Dictionary<char, Suit> s_charToSuit = new Dictionary<char, Suit>
        {
            ['C'] = Suit.Clubs,
            ['H'] = Suit.Hearts,
            ['S'] = Suit.Spades,
            ['D'] = Suit.Diamonds,
        };

        public Card Parse(string card)
        {
            if (card.Length != 2)
            {
                throw new ArgumentException("card type should be a 2 char string");
            }
            return new Card(s_charToCardRank[card[0]], s_charToSuit[card[1]]);
        }
    }
}
