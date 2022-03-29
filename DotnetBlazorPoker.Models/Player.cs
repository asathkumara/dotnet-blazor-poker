using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Represents a player
    /// </summary>
    public class Player
    {
        public decimal Balance { get; set; }

        public Hand Hand { get; set; }

        /// <summary>
        /// Constructs a player with the given balance
        /// </summary>
        /// <param name="balance">The initial balance for the player</param>
        public Player(decimal balance)
        {
            Balance = balance;
        }
    }
}
