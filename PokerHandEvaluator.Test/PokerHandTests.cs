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
        [TestMethod]
        public void ShouldReturnTrueOnOnePair()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.King, SuitType.Diamonds), new Card(RankType.King, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs), new Card(RankType.Two, SuitType.Hearts)
            );
            hand.IsValid(HandType.OnePair).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnTwoPairs()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.King, SuitType.Diamonds), new Card(RankType.Two, SuitType.Clubs),
                new Card(RankType.Ace, SuitType.Clubs), new Card(RankType.Two, SuitType.Hearts)
            );
            hand.IsValid(HandType.TwoPairs).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnThreeOfAKind()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.Two, SuitType.Diamonds), new Card(RankType.Two, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs), new Card(RankType.Two, SuitType.Hearts)
            );
            hand.IsValid(HandType.ThreeOfAKind).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnStraight()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Seven, SuitType.Spades), new Card(RankType.Five, SuitType.Diamonds), new Card(RankType.Four, SuitType.Clubs),
                new Card(RankType.Three, SuitType.Clubs), new Card(RankType.Six, SuitType.Hearts)
            );
            hand.IsValid(HandType.Straight).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnStraightAceLow()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Three, SuitType.Spades), new Card(RankType.Five, SuitType.Diamonds), new Card(RankType.Four, SuitType.Clubs),
                new Card(RankType.Two, SuitType.Clubs), new Card(RankType.Ace, SuitType.Hearts)
            );
            hand.IsValid(HandType.Straight).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnStraightAceHigh()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ten, SuitType.Spades), new Card(RankType.Queen, SuitType.Diamonds), new Card(RankType.King, SuitType.Clubs),
                new Card(RankType.Jack, SuitType.Clubs), new Card(RankType.Ace, SuitType.Hearts)
            );
            hand.IsValid(HandType.Straight).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnFlush()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Spades), new Card(RankType.King, SuitType.Spades), new Card(RankType.Queen, SuitType.Spades),
                new Card(RankType.Nine, SuitType.Spades), new Card(RankType.Two, SuitType.Spades)
            );
            hand.IsValid(HandType.Flush).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnFullHouse()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Six, SuitType.Spades), new Card(RankType.Six, SuitType.Diamonds), new Card(RankType.Two, SuitType.Clubs),
                new Card(RankType.Six, SuitType.Clubs), new Card(RankType.Two, SuitType.Hearts)
            );
            hand.IsValid(HandType.FullHouse).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnFourOfAKInd()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Four, SuitType.Spades), new Card(RankType.Five, SuitType.Diamonds), new Card(RankType.Four, SuitType.Clubs),
                new Card(RankType.Four, SuitType.Diamonds), new Card(RankType.Four, SuitType.Hearts)
            );
            hand.IsValid(HandType.FourOfAKInd).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnStraightFlush()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Seven, SuitType.Clubs), new Card(RankType.Ten, SuitType.Clubs), new Card(RankType.Jack, SuitType.Clubs),
                new Card(RankType.Nine, SuitType.Clubs), new Card(RankType.Eight, SuitType.Clubs)
            );
            hand.IsValid(HandType.StraightFlush).Should().BeTrue();
        }
        [TestMethod]
        public void ShouldReturnTrueOnRoyalFlush()
        {
            PokerHand hand = new PokerHand
            (
                new Card(RankType.Ace, SuitType.Diamonds), new Card(RankType.Ten, SuitType.Diamonds), new Card(RankType.Queen, SuitType.Diamonds),
                new Card(RankType.King, SuitType.Diamonds), new Card(RankType.Jack, SuitType.Diamonds)
            );
            hand.IsValid(HandType.RoyalFlush).Should().BeTrue();
        }
    }
}