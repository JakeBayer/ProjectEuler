﻿using Card.PlayingCards.Parse;
using System.IO;
using System.Linq;
using Card.PlayingCards.Poker;
using Card.PlayingCards.Poker.PokerHandComparer;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public class Problem54 : IProblem
    {
        public string Run()
        {
            var cardParser = new StandardParser();
            var handComparer = new PokerHandComparer();

            int winningHands = 0;

            var reader = FileHelper.ForProblem(54).OpenFile("poker.txt");
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
