namespace Card.PlayingCards.Poker.PokerHandComparer
{
    public class StraightFlushComparer : StraightComparer
    {
        protected override PokerHandRank RankToCompare => PokerHandRank.StraightFlush;
    }
}
