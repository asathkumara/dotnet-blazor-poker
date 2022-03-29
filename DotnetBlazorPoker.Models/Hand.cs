using System.Collections;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Represents a hand
    /// </summary>
    /// <remarks>Extends enumerable functionality on the cards</remarks>
    public class Hand : IEnumerable<Card>
    {
        private List<Card> _cards;

        public PokerHand PokerHand => PokerHandEvaluator.EvaluatePokerHand(_cards);

        /// <summary>
        /// Constructs a hand using the given cards
        /// </summary>
        /// <param name="cards">The cards in the hand</param>
        public Hand(List<Card> cards)
        {
            _cards = cards;
        }

        /// <summary>
        /// Retrieves a card at the given index
        /// </summary>
        /// <param name="index">The index of the card</param>
        /// <returns>The card at the given index</returns>
        public Card this[int index]
        {
            get
            {
                return _cards[index];
            }
            set
            {
                _cards[index] = value;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }
    }
}


