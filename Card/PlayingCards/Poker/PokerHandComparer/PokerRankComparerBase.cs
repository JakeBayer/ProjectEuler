﻿using System;
using System.Collections.Generic;

namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public abstract class PokerRankComparerBase : IComparer<PokerHand>
    {
        protected abstract PokerHandRank RankToCompare { get; }
        public int Compare(PokerHand x, PokerHand y)
        {
            if (x.Rank != RankToCompare || y.Rank != RankToCompare)
            {
                throw new InvalidOperationException($"One of these hands is not of the correct rank. I can only compare two {RankToCompare}");
            }
            return CompareValidated(x, y);
        }

        protected abstract int CompareValidated(PokerHand x, PokerHand y);
    }
}
