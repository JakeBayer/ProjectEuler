using ProjectEuler.Cards;
using ProjectEuler.Cards.Poker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem54 : IProblem
    {
        public string Run()
        {
            var cardParser = new StandardParser();
            var handComparer = new PokerHandComparer();

            int winningHands = 0;

            StreamReader reader = new StreamReader(@"~\..\..\..\Problems\51-100\51-60\Problem54\poker.txt");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var cards = line.Split(' ');
                var hand1 = new PokerHand(cards.Take(5).Select(str => new PokerCard(cardParser.Parse(str))));
                var hand2 = new PokerHand(cards.Skip(5).Select(str => new PokerCard(cardParser.Parse(str))));
                if (handComparer.Compare(hand1, hand2) > 0)
                {
                    winningHands++;
                }
            }
            reader.Close();

            return winningHands.ToString();
        }
    }
}
