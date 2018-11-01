using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator
{
    public enum RankType : int { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}
    public enum SuitType : int { Spades, Hearts, Diamonds, Clubs}
    public enum HandType : int { RoyalFlush, StraightFlush, FourOfAKInd, FullHouse, Flush, Straight, ThreeOfAKind, TwoPairs, OnePair, HighCard}
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

    public class PokerHand : IComparable<PokerHand>
    {
        public Card[] Cards { get; private set; }

        public PokerHand(Card c1, Card c2, Card c3, Card c4, Card c5)
        {
            Cards = new Card[]{c1, c2, c3, c4, c5};
            Sort();

            if (GetGroupByRankCount(5) != 0)
                throw new Exception("Nem lehet öt egyforma értékű lapja!");
            if (HasDuplicates())
                throw new Exception("Nem lehetnek egyforma lapjai!");
        }

        private void Sort()
        {
            Cards = Cards.OrderBy(c => c.Rank).OrderBy(c => Cards.Where(c1 => c1.Rank == c.Rank).Count()).ToArray();

            if (Cards[4].Rank == RankType.Ace && Cards[0].Rank == RankType.Two && (int)Cards[3].Rank - (int)Cards[0].Rank == 3)
                Cards = new Card[] { Cards[4], Cards[0], Cards[1], Cards[2], Cards[3] };
        }

        public int CompareTo(PokerHand other)
        {
            for (int i = 4; i >= 0; i--)
            {
                RankType rank1 = Cards[i].Rank;
                RankType rank2 = other.Cards[i].Rank;
                if (rank1 > rank2)
                    return 1;
                if (rank1 < rank2)
                    return -1;
            }
            return 0;
        }

        public bool IsValid(HandType handType)
        {
            switch (handType)
            {
                case HandType.RoyalFlush:
                    return IsValid(HandType.StraightFlush) && Cards[4].Rank == RankType.Ace;
                case HandType.StraightFlush:
                    return IsValid(HandType.Flush) && IsValid(HandType.Straight);
                case HandType.FourOfAKInd:
                    return GetGroupByRankCount(4) == 1;
                case HandType.FullHouse:
                    return IsValid(HandType.ThreeOfAKind) && IsValid(HandType.OnePair);
                case HandType.Flush:
                    return GetGroupBySuitCount(5) == 1;
                case HandType.Straight:
                    return (int)Cards[4].Rank - (int)Cards[0].Rank == 4 || Cards[0].Rank == RankType.Ace;
                case HandType.ThreeOfAKind:
                    return GetGroupByRankCount(3) == 1;
                case HandType.TwoPairs:
                    return GetGroupByRankCount(2) == 2;
                case HandType.OnePair:
                    return GetGroupByRankCount(2) == 1;
                case HandType.HighCard:
                    return GetGroupByRankCount(1) == 1;
            }
            return false;
        }

        private int GetGroupByRankCount(int n)
        {
            return Cards.GroupBy(c => c.Rank).Count(g => g.Count() == n);
        }

        private int GetGroupBySuitCount(int n)
        {
            return Cards.GroupBy(c => c.Suit).Count(g => g.Count() == n);
        }

        public static IList<string> Evaluate(IDictionary<string, PokerHand> hands)
        {
            if (HasDuplicates(hands.Values.ToList()))
                throw new Exception("Egyforma lapok vannak kiosztva!");
            var len = Enum.GetValues(typeof(HandType)).Length;
            var winners = new List<string>();
            HandType winningType = HandType.HighCard;

            foreach (var name in hands.Keys)
            {
                for (var handType = HandType.RoyalFlush; (int)handType < len; handType = handType + 1)
                {
                    var hand = hands[name];
                    if (hand.IsValid(handType))
                    {
                        int compareHands = 0;
                        int compareCards = 0;
                        if (winners.Count == 0 || (compareHands = winningType.CompareTo(handType)) > 0 || compareHands == 0 && (compareCards = hand.CompareTo(hands[winners[0]])) >= 0)
                        {
                            if (compareHands > 0 || compareCards > 0)
                                winners.Clear();
                            winners.Add(name);
                            winningType = handType;
                        }
                        break;
                    }
                }
            }
            return winners;
        }

        public bool Contains(Card card)
        {
            return Cards.Where(c=>c.Rank == card.Rank && c.Suit == card.Suit).Any();
        }

        public bool HasDuplicates()
        {
            return Cards.GroupBy(c=> new {c.Rank, c.Suit }).Where(c=>c.Skip(1).Any()).Any();
        }

        public static bool HasDuplicates(IList<PokerHand> hands)
        {
            for (int i = 0; i < hands.Count; i++)
            {
                foreach (var card in hands[i].Cards)
                {
                    for (int j = 0; j < hands.Count; j++)
                    {
                        if (i != j && hands[j].Contains(card))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
