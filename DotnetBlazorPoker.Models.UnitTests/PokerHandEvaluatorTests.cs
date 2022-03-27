using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models.UnitTests
{
    [TestFixture]
    public class PokerHandEvaluatorTests
    {
        static IEnumerable<List<Card>> GetTestHand(PokerHand pokerHand)
        {
            if (pokerHand == PokerHand.Flush)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Two),
                    new Card(Suit.Clubs, Rank.Jack),
                    new Card(Suit.Clubs, Rank.Ten),
                    new Card(Suit.Clubs, Rank.Three),
                    new Card(Suit.Clubs, Rank.Nine)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Three),
                    new Card(Suit.Diamonds, Rank.Four),
                    new Card(Suit.Diamonds, Rank.Five),
                    new Card(Suit.Diamonds, Rank.Six)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Spades, Rank.Three),
                    new Card(Suit.Spades, Rank.Four),
                    new Card(Suit.Spades, Rank.Five),
                    new Card(Suit.Spades, Rank.Six)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Three),
                    new Card(Suit.Hearts, Rank.Four),
                    new Card(Suit.Hearts, Rank.Five),
                    new Card(Suit.Hearts, Rank.Six)
                };
            }

            if (pokerHand == PokerHand.Straight)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Two),
                    new Card(Suit.Diamonds, Rank.Three),
                    new Card(Suit.Spades, Rank.Four),
                    new Card(Suit.Hearts, Rank.Five),
                    new Card(Suit.Clubs, Rank.Six)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Three),
                    new Card(Suit.Diamonds, Rank.Four),
                    new Card(Suit.Spades, Rank.Five),
                    new Card(Suit.Hearts, Rank.Six),
                    new Card(Suit.Clubs, Rank.Seven)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Four),
                    new Card(Suit.Diamonds, Rank.Five),
                    new Card(Suit.Spades, Rank.Six),
                    new Card(Suit.Hearts, Rank.Seven),
                    new Card(Suit.Clubs, Rank.Eight)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Five),
                    new Card(Suit.Diamonds, Rank.Six),
                    new Card(Suit.Spades, Rank.Seven),
                    new Card(Suit.Hearts, Rank.Eight),
                    new Card(Suit.Clubs, Rank.Nine)
                };
            }

            if (pokerHand == PokerHand.StraightFlush)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Two),
                    new Card(Suit.Clubs, Rank.Three),
                    new Card(Suit.Clubs, Rank.Four),
                    new Card(Suit.Clubs, Rank.Five),
                    new Card(Suit.Clubs, Rank.Six)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Diamonds, Rank.Three),
                    new Card(Suit.Diamonds, Rank.Four),
                    new Card(Suit.Diamonds, Rank.Five),
                    new Card(Suit.Diamonds, Rank.Six),
                    new Card(Suit.Diamonds, Rank.Seven)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Spades, Rank.Four),
                    new Card(Suit.Spades, Rank.Five),
                    new Card(Suit.Spades, Rank.Six),
                    new Card(Suit.Spades, Rank.Seven),
                    new Card(Suit.Spades, Rank.Eight)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Hearts, Rank.Five),
                    new Card(Suit.Hearts, Rank.Six),
                    new Card(Suit.Hearts, Rank.Seven),
                    new Card(Suit.Hearts, Rank.Eight),
                    new Card(Suit.Hearts, Rank.Nine)
                };
            }

            if (pokerHand == PokerHand.RoyalFlush)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ten),
                    new Card(Suit.Clubs, Rank.Jack),
                    new Card(Suit.Clubs, Rank.Queen),
                    new Card(Suit.Clubs, Rank.King),
                    new Card(Suit.Clubs, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Diamonds,Rank.Ten),
                    new Card(Suit.Diamonds, Rank.Jack),
                    new Card(Suit.Diamonds, Rank.Queen),
                    new Card(Suit.Diamonds, Rank.King),
                    new Card(Suit.Diamonds, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Hearts, Rank.Ten),
                    new Card(Suit.Hearts, Rank.Jack),
                    new Card(Suit.Hearts, Rank.Queen),
                    new Card(Suit.Hearts, Rank.King),
                    new Card(Suit.Hearts, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Spades, Rank.Ten),
                    new Card(Suit.Spades, Rank.Jack),
                    new Card(Suit.Spades, Rank.Queen),
                    new Card(Suit.Spades, Rank.King),
                    new Card(Suit.Spades, Rank.Ace)
                };
            }

            if (pokerHand == PokerHand.FullHouse)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.King),
                    new Card(Suit.Spades, Rank.King),
                    new Card(Suit.Diamonds, Rank.King),
                    new Card(Suit.Hearts, Rank.Three),
                    new Card(Suit.Clubs, Rank.Three)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Two),
                    new Card(Suit.Spades, Rank.Two),
                    new Card(Suit.Diamonds, Rank.Two),
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Clubs, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Four),
                    new Card(Suit.Spades, Rank.Four),
                    new Card(Suit.Diamonds, Rank.Ten),
                    new Card(Suit.Hearts, Rank.Ten),
                    new Card(Suit.Clubs, Rank.Ten)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Five),
                    new Card(Suit.Spades, Rank.Five),
                    new Card(Suit.Diamonds, Rank.Seven),
                    new Card(Suit.Hearts, Rank.Seven),
                    new Card(Suit.Clubs, Rank.Seven)
                };
            }

            if (pokerHand == PokerHand.FourOfAKind)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Clubs, Rank.Three)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Jack),
                    new Card(Suit.Spades, Rank.Jack),
                    new Card(Suit.Diamonds, Rank.Jack),
                    new Card(Suit.Hearts, Rank.Jack),
                    new Card(Suit.Clubs, Rank.Two)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ten),
                    new Card(Suit.Spades, Rank.Ten),
                    new Card(Suit.Diamonds, Rank.Five),
                    new Card(Suit.Hearts, Rank.Ten),
                    new Card(Suit.Clubs, Rank.Ten)
                };

                yield return new List<Card>()
               {
                    new Card(Suit.Clubs, Rank.King),
                    new Card(Suit.Spades, Rank.Queen),
                    new Card(Suit.Diamonds, Rank.Queen),
                    new Card(Suit.Hearts, Rank.Queen),
                    new Card(Suit.Clubs, Rank.Queen)
               };
            }

            if (pokerHand == PokerHand.ThreeOfAKind)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Two),
                    new Card(Suit.Clubs, Rank.Three)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Five),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Clubs, Rank.Jack)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Five),
                    new Card(Suit.Spades, Rank.Ten),
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Clubs, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Queen),
                    new Card(Suit.Diamonds, Rank.King),
                    new Card(Suit.Hearts, Rank.Ace),
                    new Card(Suit.Clubs, Rank.Ace)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Eight),
                    new Card(Suit.Hearts, Rank.Nine),
                    new Card(Suit.Clubs, Rank.Ace)
                };
            }

            if (pokerHand == PokerHand.TwoPair)
            {
                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Three),
                    new Card(Suit.Hearts, Rank.Three),
                    new Card(Suit.Clubs, Rank.Eight)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Nine),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Ace),
                    new Card(Suit.Hearts, Rank.Five),
                    new Card(Suit.Clubs, Rank.Five)
                };

                yield return new List<Card>()
                {
                    new Card(Suit.Clubs, Rank.Ace),
                    new Card(Suit.Spades, Rank.Ace),
                    new Card(Suit.Diamonds, Rank.Queen),
                    new Card(Suit.Hearts, Rank.King),
                    new Card(Suit.Clubs, Rank.King)
                };
            }
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void IsFlush_OnFlush_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsFlush(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void IsStraight_OnStraight_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsStraight(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void IsStraightFlush_OnStraightFlush_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsStraightFlush(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void IsRoyalFlush_OnRoyalFlush_ReturnsTrue(List<Card> testHand)
        {
            bool result = PokerHandEvaluator.IsRoyalFlush(testHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void IsFullHouse_OnFullHouse_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsFullHouse(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void IsFourOfAKind_OnFourOfAKind_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsFourOfAKind(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void IsThreeOfAKind_OnThreeOfAKind_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsThreeOfAKind(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void IsTwoPair_OnTwoPair_ReturnsTrue(List<Card> testHand)
        {
            Assert.That(PokerHandEvaluator.IsTwoPair(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void EvaluatePokerHand_AssignsFlush_ReturnsTrue(List<Card> testHand)
        {
            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Flush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void EvaluatePokerHand_AssignsStraight_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Straight);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void EvaluatePokerHand_AssignsStraightFlush_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.StraightFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void EvaluatePokerHand_AssignsRoyalFlush_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.RoyalFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void EvaluatePokerHand_AssignsFullHouse_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FullHouse);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void EvaluatePokerHand_AssignsFourOfAKind_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FourOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void EvaluatePokerHand_AssignsThreeOfAKind_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.ThreeOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void EvaluatePokerHand_AssignsTwoPair_ReturnsTrue(List<Card> testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.TwoPair);

        }
    }
}
