using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    public class Player
    {
        public decimal Balance { get; set; }

        public Hand Hand { get; set; }

        public Player(decimal balance)
        {
            Balance = balance;
        }
    }
}
