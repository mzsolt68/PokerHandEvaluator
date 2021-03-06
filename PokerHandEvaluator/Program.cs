﻿using System;
using System.Collections.Generic;

namespace PokerHandEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
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
                new Card(RankType.Ace, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs),
                new Card(RankType.Ten, SuitType.Clubs),
                new Card(RankType.Two, SuitType.Clubs),
                new Card(RankType.Seven, SuitType.Clubs)
                )
            };
            List<Player> players = new List<Player> { p1, p2 };
            foreach (var player in PokerHand.Evaluate(players))
            {
                Console.WriteLine($"{player.Name} lapja: {player.HandType}");
            }

            Console.Read();
        }
    }
}
