using System.Collections;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Represents a deck of playing cards
    /// </summary>
    /// <remarks>Extends enumerable functionality on the cards</remarks>
    public class Deck : IEnumerable<Card>
    {
        private const int MaxDeckSize = 52;

        private List<Card> _cards;
        private List<Card> _cachedCards;

        /// <summary>
        /// Constructs a deck of 52 playing cards
        /// </summary>
        /// <remarks>The deck is cached to optimize for resetting</remarks>
        public Deck()
        {
            _cards = new List<Card>(MaxDeckSize);
            _cachedCards = new List<Card>(MaxDeckSize);

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(suit, rank));
                    _cachedCards.Add(new Card(suit, rank));
                }
            }
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

        /// <summary>
        /// Retrieves the top card on the deck
        /// </summary>
        /// <returns>The card on the top of the deck</returns>
        public Card Pop()
        {
            Card topCard = _cards[0];
            _cards.RemoveAt(0);

            return topCard;
        }

        /// <summary>
        /// Resets the deck
        /// </summary>
        public void Reset()
        {
            _cards.Clear();
            _cards.AddRange(_cachedCards);
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


