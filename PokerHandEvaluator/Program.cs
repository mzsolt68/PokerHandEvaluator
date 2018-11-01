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
            Player p1 = new Player
            {
                Name = "Player1",
                Hand = new PokerHand
                (
                new Card(RankType.Ace, SuitType.Spades),
                new Card(RankType.King, SuitType.Hearts),
                new Card(RankType.Ten, SuitType.Hearts),
                new Card(RankType.Ten, SuitType.Spades),
                new Card(RankType.Ace, SuitType.Hearts)
                )
            };
            Player p2 = new Player
            {
                Name = "Player2",
                Hand = new PokerHand
                (
                new Card(RankType.Ace, SuitType.Diamonds),
                new Card(RankType.King, SuitType.Diamonds),
                new Card(RankType.Queen, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Diamonds),
                new Card(RankType.Two, SuitType.Hearts)
                )
            };
            Player p3 = new Player
            {
                Name = "Player3",
                Hand = new PokerHand
                (
                new Card(RankType.Ace, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs),
                new Card(RankType.Ten, SuitType.Clubs),
                new Card(RankType.Two, SuitType.Clubs),
                new Card(RankType.Seven, SuitType.Clubs)
                )
            };
            hands.Add(p1.Name, p1.Hand);
            hands.Add(p2.Name, p2.Hand);
            hands.Add(p3.Name, p3.Hand);
            foreach (var player in PokerHand.Evaluate(hands))
            {
                Console.WriteLine($"{player.Name} lapja: {player.HandType}");
            }

            Console.Read();
        }
    }
}
