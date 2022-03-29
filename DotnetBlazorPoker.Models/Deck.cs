using System.Collections;

namespace DotnetBlazorPoker.Models
{
    public class Deck : IEnumerable<Card>
    {
        private const int MaxDeckSize = 52;

        private List<Card> _cards;
        private List<Card> _cachedCards;

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

        public Card Pop()
        {
            Card topCard = _cards[0];
            _cards.RemoveAt(0);
            return topCard;
        }

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


