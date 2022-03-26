using System.Collections;

namespace DotnetBlazorPoker.Models
{
    public class Deck : IEnumerable<Card>
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public Card this[int index]
        {
            get
            {
                return _cards[index];
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


