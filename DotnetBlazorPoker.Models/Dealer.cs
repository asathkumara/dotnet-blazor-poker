using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    
    public class Dealer
    {
        private Deck _deck;
        private Random _random;

        public Dealer()
        {
            _deck = new Deck();
            _random = new Random();
            ShuffleDeck();
        }

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

        public Card DealCard()
        {
            if (_deck.Count() == 0)
            {
                _deck.Reset();
                ShuffleDeck();
            }

            return _deck.Pop();
        }

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
