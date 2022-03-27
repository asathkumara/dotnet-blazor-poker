using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    public static class PokerHandEvaluator
    {
        static List<Predicate<List<Card>>> _evaluators;
        static Dictionary<string, PokerHand> _evaluations;
        static Func<Card, Card, bool> _pairwiseRankEvaluator;


        static PokerHandEvaluator()
        {
            _evaluators = new List<Predicate<List<Card>>>()
            {
                IsRoyalFlush,
                IsStraightFlush,
                IsFourOfAKind,
                IsFullHouse,
                IsFlush,
                IsStraight,
                IsThreeOfAKind,
                IsTwoPair
            };

            _evaluations = new Dictionary<string, PokerHand>()
            {
                {nameof(IsRoyalFlush), PokerHand.RoyalFlush },
                {nameof(IsStraightFlush), PokerHand.StraightFlush },
                {nameof(IsFourOfAKind), PokerHand.FourOfAKind },
                {nameof(IsFullHouse), PokerHand.FullHouse },
                {nameof(IsFlush), PokerHand.Flush },
                {nameof(IsStraight), PokerHand.Straight },
                {nameof(IsThreeOfAKind), PokerHand.ThreeOfAKind },
                {nameof(IsTwoPair), PokerHand.TwoPair },
            };

            _pairwiseRankEvaluator = (firstCard, secondCard) => (int)firstCard.Rank == (int)secondCard.Rank;
        }

        public static bool IsFlush(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Suit).ToList();

            return hand[0].Suit.Equals(hand[hand.Count - 1].Suit);
        }

        public static bool IsStraight(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            int sequentialRank = (int)hand[0].Rank + 1;

            for (int i = 1; i < hand.Count; i++)
            {
                if ((int)hand[i].Rank != sequentialRank)
                {
                    return false;
                }

                sequentialRank++;
            }

            return true;
        }

        public static bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        public static bool IsRoyalFlush(List<Card> hand)
        {
            return IsStraight(hand) && hand[hand.Count - 1].Rank.Equals(Rank.Ace);
        }

        public static bool IsFullHouse(List<Card> hand)
        {
            hand.OrderBy(card => (int)card.Rank);

            bool isLowFullHouse = IsPairwise(hand, 0, 2, _pairwiseRankEvaluator) &&
                                   IsPairwise(hand, 3, 4, _pairwiseRankEvaluator);

            bool isHighFullHouse = IsPairwise(hand, 0, 1, _pairwiseRankEvaluator) &&
                                    IsPairwise(hand, 2, 4, _pairwiseRankEvaluator);

            return isLowFullHouse || isHighFullHouse;
        }

        public static bool IsFourOfAKind(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowFourOfAKind = IsPairwise(hand, 0, 3, _pairwiseRankEvaluator);
            bool isHighFourOfAKind = IsPairwise(hand, 1, 4, _pairwiseRankEvaluator);

            return isLowFourOfAKind || isHighFourOfAKind;
        }

        public static bool IsThreeOfAKind(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowThreeOfAKind = IsPairwise(hand, 0, 2, _pairwiseRankEvaluator);
            bool isMidThreeOfAKind = IsPairwise(hand, 1, 3, _pairwiseRankEvaluator);
            bool isHighThreeOfAKind = IsPairwise(hand, 2, 4, _pairwiseRankEvaluator);

            return isLowThreeOfAKind || isMidThreeOfAKind || isHighThreeOfAKind;
        }

        public static bool IsTwoPair(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowTwoPair = IsPairwise(hand, 0, 3, _pairwiseRankEvaluator, 2);
            bool isCornerTwoPair = IsPairwise(hand, 0, 4, _pairwiseRankEvaluator, 3);
            bool isHighTwoPair = IsPairwise(hand, 1, 4, _pairwiseRankEvaluator, 2);

            return isLowTwoPair || isCornerTwoPair || isHighTwoPair;
        }

        private static bool IsPairwise(List<Card> hand, int startIndex, int stopIndex, Func<Card, Card, bool> pairwiseEvaluator, int step = 1)
        {
            bool isPairwise = true;

            for (int i = startIndex; i < stopIndex; i += step)
            {
                isPairwise = pairwiseEvaluator(hand[i], hand[i + 1]);

                if (!isPairwise)
                {
                    return false;
                }
            }

            return isPairwise;
        }

        public static PokerHand EvaluatePokerHand(List<Card> cards)
        {
            foreach (Predicate<List<Card>> handEvaluator in _evaluators)
            {
                bool matchesEvaluation = handEvaluator(cards);
                
                if (matchesEvaluation)
                {
                   string key = handEvaluator.Method.Name;
                   return _evaluations[key];
                }
            }

            return PokerHand.None;
        }
    }
}
