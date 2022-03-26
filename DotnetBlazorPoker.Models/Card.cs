namespace DotnetBlazorPoker.Models
{
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(Card? other)
        {
            return Rank.CompareTo(other?.Rank);
        }

        public override string ToString()
        {
            return $"{Suit.ToString().ToLower()}-{Rank.ToString().ToLower()}";
        }
    }
}


