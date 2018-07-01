using System;
using System.Collections.Generic;

namespace PokerHandEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<string, PokerHand> hands = new Dictionary<string, PokerHand>();
            PokerHand hand1 = new PokerHand
                (
                new Card(RankType.Ace, SuitType.Spades),
                new Card(RankType.King, SuitType.Hearts),
                new Card(RankType.Ten, SuitType.Hearts),
                new Card(RankType.Ten, SuitType.Spades),
                new Card(RankType.Ace, SuitType.Hearts)
                );
            PokerHand hand2 = new PokerHand
                (
                new Card (RankType.Ace, SuitType.Clubs ),
                new Card ( RankType.Nine, SuitType.Clubs ),
                new Card ( RankType.Ten, SuitType.Clubs ),
                new Card ( RankType.Two, SuitType.Clubs ),
                new Card ( RankType.Seven, SuitType.Clubs )
                );
            hands.Add("hand1", hand1);
            hands.Add("hand2", hand2);
            foreach (var player in PokerHand.Evaluate(hands))
            {
                Console.WriteLine(player);
            }

            Console.Read();
        }
    }
}
