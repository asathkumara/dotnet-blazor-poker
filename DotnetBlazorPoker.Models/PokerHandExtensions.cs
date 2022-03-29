using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    public static class PokerHandExtensions
    {
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
