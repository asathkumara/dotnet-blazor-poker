using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Evaluates a poker hand
    /// </summary>
    public static class PokerHandEvaluator
    {
        /// <summary>
        /// The evaluator functions to be used
        /// </summary>
        static List<Predicate<List<Card>>> _evaluators;

        /// <summary>
        /// The evaluations to be handed out for a poker hand
        /// </summary>
        static Dictionary<string, PokerHand> _evaluations;

        /// <summary>
        /// The pairwise evaluator for ranks
        /// </summary>
        static Func<Card, Card, bool> _pairwiseRankEvaluator;

        /// <summary>
        /// Initializes the PokerHandEvaluator
        /// </summary>
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

        /// <summary>
        /// Evaluates the given hand for a Flush 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Flush; False otherwise</returns>
        public static bool IsFlush(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Suit).ToList();

            return hand[0].Suit.Equals(hand[hand.Count - 1].Suit);
        }

        /// <summary>
        /// Evaluates the given hand for a Straight 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Straight; False otherwise</returns>
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

        /// <summary>
        /// Evaluates the given hand for a Straight Flush 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Straight Flush; False otherwise</returns>
        public static bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        /// <summary>
        /// Evaluates the given hand for a Royal Flush 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Royal Flush; False otherwise</returns>
        public static bool IsRoyalFlush(List<Card> hand)
        {
            return IsStraight(hand) && hand[hand.Count - 1].Rank.Equals(Rank.Ace);
        }

        /// <summary>
        /// Evaluates the given hand for a Full House 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Full House; False otherwise</returns>
        public static bool IsFullHouse(List<Card> hand)
        {
            hand.OrderBy(card => (int)card.Rank);

            bool isLowFullHouse = IsPairwise(hand, 0, 2, _pairwiseRankEvaluator) &&
                                   IsPairwise(hand, 3, 4, _pairwiseRankEvaluator);

            bool isHighFullHouse = IsPairwise(hand, 0, 1, _pairwiseRankEvaluator) &&
                                    IsPairwise(hand, 2, 4, _pairwiseRankEvaluator);

            return isLowFullHouse || isHighFullHouse;
        }

        /// <summary>
        /// Evaluates the given hand for a Four of a kind 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Four of a kind; False otherwise</returns>
        public static bool IsFourOfAKind(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowFourOfAKind = IsPairwise(hand, 0, 3, _pairwiseRankEvaluator);
            bool isHighFourOfAKind = IsPairwise(hand, 1, 4, _pairwiseRankEvaluator);

            return isLowFourOfAKind || isHighFourOfAKind;
        }

        /// <summary>
        /// Evaluates the given hand for a Three of a kind 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Three of a kind; False otherwise</returns>
        public static bool IsThreeOfAKind(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowThreeOfAKind = IsPairwise(hand, 0, 2, _pairwiseRankEvaluator);
            bool isMidThreeOfAKind = IsPairwise(hand, 1, 3, _pairwiseRankEvaluator);
            bool isHighThreeOfAKind = IsPairwise(hand, 2, 4, _pairwiseRankEvaluator);

            return isLowThreeOfAKind || isMidThreeOfAKind || isHighThreeOfAKind;
        }

        /// <summary>
        /// Evaluates the given hand for a Two Pair 
        /// </summary>
        /// <param name="hand">The hand to be evaluated</param>
        /// <returns>True if the given hand is a Two Pair; False otherwise</returns>
        public static bool IsTwoPair(List<Card> hand)
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToList();

            bool isLowTwoPair = IsPairwise(hand, 0, 3, _pairwiseRankEvaluator, 2);
            bool isCornerTwoPair = IsPairwise(hand, 0, 4, _pairwiseRankEvaluator, 3);
            bool isHighTwoPair = IsPairwise(hand, 1, 4, _pairwiseRankEvaluator, 2);

            return isLowTwoPair || isCornerTwoPair || isHighTwoPair;
        }

        /// <summary>
        /// Checks whether the given hand meets the criteria specified by the pairwise evaluator.
        /// </summary>
        /// <param name="hand">The hand to be evaluated pairwise</param>
        /// <param name="startIndex">The index to start the evaluations at</param>
        /// <param name="stopIndex">The index to stop the evaluations at</param>
        /// <param name="pairwiseEvaluator">The pairwise evaluator to be used</param>
        /// <param name="step">The increment to be used for the evaluations</param>
        /// <returns>True if the hand meets the evaluator's criteria; False otherwise.</returns>
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

        /// <summary>
        /// Evaluates the given list of cards for a Poker Hand
        /// </summary>
        /// <param name="cards">The cards to be evaluated</param>
        /// <returns>The Poker Hand of the cards</returns>
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
