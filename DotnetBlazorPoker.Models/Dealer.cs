using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Represents a Dealer
    /// </summary>
    public class Dealer
    {
        private Deck _deck;
        private Random _random;

        /// <summary>
        /// Constructs a Dealer
        /// </summary>
        /// <remarks>The dealer shuffles the deck on construction</remarks>
        public Dealer()
        {
            _deck = new Deck();
            _random = new Random();

            ShuffleDeck();
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        /// <remarks>Employs the Fisher-Yates algorithm for shuffling</remarks>
        private void ShuffleDeck()
        {
            for (int i = _deck.Count() - 1; i >= 0; i--)
            {
                int secondCardIndex = _random.Next(0, 52);
                Card temp = _deck[i];
                _deck[i] = _deck[secondCardIndex];
                _deck[secondCardIndex] = temp;
            }
        }

        /// <summary>
        /// Deals a card
        /// </summary>
        /// <returns>A card from the deck</returns>
        public Card DealCard()
        {
            if (_deck.Count() == 0)
            {
                _deck.Reset();
                ShuffleDeck();
            }

            return _deck.Pop();
        }

        /// <summary>
        /// Deals the given amount of cards
        /// </summary>
        /// <param name="numberOfCards">The amount of cards to be dealt</param>
        /// <returns>The given amount of cards</returns>
        public List<Card> DealCards(int numberOfCards)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                cards.Add(DealCard());
            }

            return cards;
        }
    }


}
