using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Contains extensions for the Poker Hand enum
    /// </summary>
    public static class PokerHandExtensions
    {
        /// <summary>
        /// Converts the PokerHand value to a readable string
        /// </summary>
        /// <param name="pokerHand">The Poker Hand value to be converted</param>
        /// <returns>A readable string representation of the Poker Hand</returns>
        public static string ToReadableString(this PokerHand pokerHand)
        {
            switch (pokerHand)
            {
                case PokerHand.TwoPair:
                    return "Two Pair";

                case PokerHand.ThreeOfAKind:
                    return "Three Of A Kind";

                case PokerHand.Straight:
                    return "Straight";

                case PokerHand.Flush:
                    return "Flush";

                case PokerHand.FullHouse:
                    return "Full House";

                case PokerHand.FourOfAKind:
                    return "Four Of A Kind";

                case PokerHand.StraightFlush:
                    return "Straight Flush";

                case PokerHand.RoyalFlush:
                    return "Royal Flush";

                case PokerHand.None:
                default:
                    return "No Poker Hand";

            }
        }
    }
}
