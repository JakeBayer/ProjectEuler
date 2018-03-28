using System;
using System.Collections.Generic;

namespace Card.PlayingCards.Poker.PokerHandEvaluator
{
    public static class PokerHandEvaluator
    {
        private class ReverseComparer : IComparer<PokerHandRank>
        {
            public int Compare(PokerHandRank x, PokerHandRank y)
            {
                return 0 - Comparer<PokerHandRank>.Default.Compare(x, y);
            }
        }

        private static readonly SortedList<PokerHandRank, IPokerRankEvaluator> s_evaluators = new SortedList<PokerHandRank, IPokerRankEvaluator>(new ReverseComparer())
        {
            [PokerHandRank.StraightFlush] = new StraightFlushEvaluator(),
            [PokerHandRank.FourOfAKind] = new FourOfAKindEvaluator(),
            [PokerHandRank.FullHouse] = new FullHouseEvaluator(),
            [PokerHandRank.Flush] = new FlushEvlauator(),
            [PokerHandRank.Straight] = new StraightEvaluator(),
            [PokerHandRank.ThreeOfAKind] = new ThreeOfAKindEvaluator(),
            [PokerHandRank.TwoPair] = new TwoPairEvaluator(),
            [PokerHandRank.Pair] = new PairEvaluator(),
            [PokerHandRank.HighCard] = new HighCardEvaluator(),
        };

        private static void ResetHand(Hand<PokerCard> hand)
        {
            foreach (var card in hand.Cards)
            {
                card.IsPassiveInHand = false;
                card.IsActiveInHand = false;
            }
        }

        public static PokerHandRank EvaluateHand(Hand<PokerCard> hand)
        {
            ResetHand(hand);
            foreach (var evaluator in s_evaluators)
            {
                if (evaluator.Value.Evaluate(hand.Cards))
                {
                    return evaluator.Key;
                }
            }
            throw new NotImplementedException();
        }
    }
}
