namespace PokerHandEvaluator
{
    public struct Card
    {
        public RankType Rank { get; private set; }
        public SuitType Suit { get; private set; }

        public Card(RankType rank, SuitType suit) : this()
        {
            Rank = rank;
            Suit = suit;
        }
    }
}