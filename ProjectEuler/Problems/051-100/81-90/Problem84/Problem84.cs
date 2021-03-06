﻿using Card.Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem84 : IProblem
    {
        private static readonly HashSet<int> s_chanceSquares = new HashSet<int> { 7, 22, 36 };
        private static readonly HashSet<int> s_communityChestSquares = new HashSet<int> { 2, 27, 33 };

        private readonly ChanceDeck _chanceDeck = new ChanceDeck();
        private readonly CommunityChestDeck _ccDeck = new CommunityChestDeck();

        public string Run()
        {
            var positionOccurrences = RunMonopolyForNTurns(10000000);
            return string.Join("", positionOccurrences
                .Select((occurence, i) => new { Occurrence = occurence, I = i })
                .OrderByDescending(x => x.Occurrence)
                .Take(3)
                .Select(x => Pad(x.I)));
        }

        private string Pad(int i)
        {
            return i < 10 ? "0" + i.ToString() : i.ToString();
        }

        private int[] RunMonopolyForNTurns(long n)
        {
            _ccDeck.Shuffle();
            _chanceDeck.Shuffle();
            Random die = new Random();
            int consecutiveDoubles = 0, currentPosition = 0;
            int[] positionOccurrences = new int[40];
            for (int i = 0; i < n; i++)
            {
                int d1 = die.Next(1, 5);
                int d2 = die.Next(1, 5);
                if (d1 == d2)
                {
                    consecutiveDoubles++;
                } 
                else
                {
                    consecutiveDoubles = 0;
                }

                if (consecutiveDoubles == 3)
                {
                    currentPosition = 10;
                    consecutiveDoubles = 0;
                }
                else // actually move
                {
                    currentPosition = (currentPosition + d1 + d2) % 40;
                    if (s_chanceSquares.Contains(currentPosition))
                    {
                        currentPosition = Chance(currentPosition);
                    }
                    if (s_communityChestSquares.Contains(currentPosition))
                    {
                        currentPosition = CommunityChest(currentPosition);
                    }
                    if (currentPosition == 30) // GO TO JAIL
                    {
                        currentPosition = 10;
                    }
                }
                positionOccurrences[currentPosition]++;
            }
            return positionOccurrences;
        }

        private int Chance(int currentPosition)
        {
            var card = _chanceDeck.DrawAndReturn();
            if (_chanceDeck.IsEmpty())
            {
                _chanceDeck.Reshuffle();
            }
            return card.FollowInstruction(currentPosition);
        }

        private int CommunityChest(int currentPosition)
        {
            var card = _ccDeck.DrawAndReturn();
            if (_ccDeck.IsEmpty())
            {
                _ccDeck.Reshuffle();
            }
            return card.FollowInstruction(currentPosition);
        }
    }
}
