using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    /// <summary>
    /// Manages the Game's state.
    /// </summary>
    public class GameStateManager
    {
        private const int MaxHandSize = 5;
        private const decimal InitialBalance = 3000;
       
        /// <summary>
        /// The multipliers to be used when awarding credits
        /// </summary>
        public Dictionary<PokerHand, decimal> PokerHandMultipliers { get; private set; }

        /// <summary>
        /// The handlers to be used on a given state
        /// </summary>
        public Dictionary<GameState, Action> GameStateHandlers { get; private set; }

        public Player Player { get; set; }

        public int CurrentBet { get; set; }

        public Dealer Dealer { get; set; }

        public string CurrentDialogue { get; set; }

        public GameState CurrentState { get; set; }

        public event Action OnGameStateChange;

        public List<int> CurrentDiscardIndices { get; set; }

        /// <summary>
        /// Constructs a GameStateManager
        /// </summary>
        public GameStateManager()
        {
            PokerHandMultipliers = new Dictionary<PokerHand, decimal>()
            {
                {PokerHand.RoyalFlush, 0.9M},
                {PokerHand.StraightFlush, 0.8M},
                {PokerHand.FourOfAKind, 0.7M},
                {PokerHand.FullHouse, 0.6M},
                {PokerHand.Flush, 0.5M},
                {PokerHand.Straight, 0.4M},
                {PokerHand.ThreeOfAKind, 0.3M},
                {PokerHand.TwoPair, 0.2M},
                {PokerHand.None, 0},
            };

            GameStateHandlers = new Dictionary<GameState, Action>()
            {
                { GameState.Deal, DealStateHandler},
                { GameState.Bet, BetStateHandler},
                { GameState.Draw, DrawStateHandler},
                { GameState.Showdown, ShowdownStateHandler},
                { GameState.GameOver, GameOverHandler},
            };

            Player = new Player(InitialBalance);
            Dealer = new Dealer();
            CurrentDiscardIndices = new List<int>();
        }

        /// <summary>
        /// The handler for when the game's state is on Deal
        /// </summary>
        public void DealStateHandler()
        {
            CurrentDialogue = "You were dealt a hand.";
            Player.Hand = new Hand(Dealer.DealCards(MaxHandSize));
            CurrentBet = 0;
        }

        /// <summary>
        /// The handler for when the game's state is on Bet
        /// </summary>
        public void BetStateHandler()
        {
            CurrentDialogue = "Place your bets.";

        }

        /// <summary>
        /// The handler for when the game's state is on Draw
        /// </summary>
        public void DrawStateHandler()
        {
            Player.Balance -= CurrentBet;
            CurrentDialogue = "Select upto 3 cards to redraw";
        }

        /// <summary>
        /// The handler for when the game's state is on Showdown
        /// </summary>
        public void ShowdownStateHandler()
        {
            AcceptRedraws();

            decimal credits = AwardCredits(Player);
            CurrentDialogue = $"{Player.Hand.PokerHand.ToReadableString()}! You were awarded {credits} credits.";

            CurrentDiscardIndices.Clear();

            if (Player.Balance == 0)
            {
                CurrentState = GameState.GameOver;
                OnGameStateChange?.Invoke();
            }
        }

        /// <summary>
        /// The handler for when the game's state is on Draw
        /// </summary>
        public void GameOverHandler()
        {
            CurrentDialogue = "Game Over";
        }

        /// <summary>
        /// Initializes the Game State
        /// </summary>
        public void InitializeGameState()
        {
            if (Player.Balance == 0)
            {
                Player.Balance = InitialBalance;
            }

            CurrentState = GameState.Deal;
            OnGameStateChange?.Invoke();
        }

        /// <summary>
        /// Advances the Game State
        /// </summary>
        /// <remarks>Cycles through available game states excluding the game over</remarks>
        public void AdvanceGameState()
        {
            GameState[] gameStates = Enum.GetValues<GameState>();
            CurrentState = gameStates[((int)CurrentState + 1) % (gameStates.Length - 1)];

            OnGameStateChange?.Invoke();
        }

        /// <summary>
        /// Accepts the redraws from the player
        /// </summary>
        private void AcceptRedraws()
        {
            foreach (int index in CurrentDiscardIndices)
            {
                Player.Hand[index] = Dealer.DealCard();
            }
        }

        /// <summary>
        /// Awards credits to the given player
        /// </summary>
        /// <param name="player">The player to be awarded credits to</param>
        /// <returns>The amount of credits awarded</returns>
        private decimal AwardCredits(Player player)
        {
            decimal credits = (int)(CurrentBet * PokerHandMultipliers[player.Hand.PokerHand]);

            if (credits > 0)
            {
                credits += CurrentBet;
                player.Balance += credits;
            }

            return credits;
        }
    }
}
