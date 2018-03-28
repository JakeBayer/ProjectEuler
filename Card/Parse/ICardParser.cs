namespace Card.Parse
{
    public interface ICardParser<out TCard>
        where TCard : CardBase
    {
        TCard Parse(string card);
    }
}
