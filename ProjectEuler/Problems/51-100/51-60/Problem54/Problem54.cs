using ProjectEuler.Cards;
using ProjectEuler.Cards.Poker;
using System;
using System.Collections.Generic;
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
            var strs = new[] { "6H", "6S", "TD", "JC", "QH", "3D" };

            var pokerHand = new PokerHand(strs.Select(str => new PokerCard(cardParser.Parse(str))));



            throw new NotImplementedException();
        }
    }
}
