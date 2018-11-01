using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace PokerHandEvaluator.Test
{
    [TestClass]
    public class PokerHandTests
    {
        [TestMethod]
        public void ShouldThrowExceptionFiveSameRank()
        {
            PokerHand hand;
            Action todo = () => hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.Ace, SuitType.Diamonds), new Card(RankType.Ace, SuitType.Clubs),
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.Ace, SuitType.Hearts)
            );
            todo.Should().Throw<Exception>();
        }
        [TestMethod]
        public void ShouldThrowExceptionTwoSameCards()
        {
            PokerHand hand;
            Action todo = () => hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.King, SuitType.Diamonds), new Card(RankType.Queen, SuitType.Clubs),
                new Card(RankType.Queen, SuitType.Clubs), new Card(RankType.Ace, SuitType.Hearts)
            );
            todo.Should().Throw<Exception>();
        }
        [TestMethod]
        public void ShouldReturnTrueOnHighCard()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.King, SuitType.Diamonds), new Card(RankType.Queen, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs), new Card(RankType.Two, SuitType.Hearts)
            );
            hand.IsValid(HandType.HighCard).Should().BeTrue();
        }
    }
}
