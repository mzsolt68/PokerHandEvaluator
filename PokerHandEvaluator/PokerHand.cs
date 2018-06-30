using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator
{
    public enum RankType : int { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}
    public enum SuitType : int { Spades, Hearts, Diamonds, Clubs}
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

    class PokerHand
    {
    }
}
