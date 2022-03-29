namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Represents a playing card
    /// </summary>
    /// <remarks>Extends comparable functionality on ranks.</remarks>
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        /// <summary>
        /// Constructs a card with the given suit and rank
        /// </summary>
        /// <param name="suit">The suit for the card</param>
        /// <param name="rank">The rank for the card</param>
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Compares two cards
        /// </summary>
        /// <param name="other">The other card to be compared against</param>
        /// <returns>An int indicative of the current cards position relative to the other card.</returns>
        public int CompareTo(Card? other)
        {
            return Rank.CompareTo(other?.Rank);
        }

        /// <summary>
        /// Converts the card to a string representation
        /// </summary>
        /// <returns>A string representation of the card</returns>
        public override string ToString()
        {
            return $"{Suit.ToString().ToLower()}-{Rank.ToString().ToLower()}";
        }
    }
}


