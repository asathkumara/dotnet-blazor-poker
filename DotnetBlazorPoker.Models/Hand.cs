using System.Collections;

namespace DotnetBlazorPoker.Models
{
    public class Hand : IEnumerable<Card>
    {
        private List<Card> _cards;

        public Hand(List<Card> cards)
        {
            _cards = cards;
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


