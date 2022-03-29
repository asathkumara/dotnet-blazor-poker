using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBlazorPoker.Models
{
    public class GameStateManager
    {
        private const int MaxHandSize = 5;
        private const decimal InitialBalance = 3000;
       
        public Dictionary<PokerHand, decimal> PokerHandMultipliers { get; private set; }

        public Dictionary<GameState, Action> GameStateHandlers { get; private set; }

        public Player Player { get; set; }

        public int CurrentBet { get; set; }

        public Dealer Dealer { get; set; }

        public string CurrentDialogue { get; set; }

        public GameState CurrentState { get; set; }

        public event Action OnGameStateChange;

        public List<int> CurrentDiscardIndices { get; set; }

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
                { GameState.Showdown, ShowdownStateHandler}
            };

            Player = new Player(InitialBalance);
            Dealer = new Dealer();
            CurrentDiscardIndices = new List<int>();
        }
        public void DealStateHandler()
        {
            CurrentDialogue = "You were dealt a hand.";
            Player.Hand = new Hand(Dealer.DealCards(MaxHandSize));
            CurrentBet = 0;
        }

        public void BetStateHandler()
        {
            CurrentDialogue = "Place your bets.";

        }

        public void DrawStateHandler()
        {
            Player.Balance -= CurrentBet;
            CurrentDialogue = "Select upto 3 cards to redraw";
        }

        public void ShowdownStateHandler()
        {
            AcceptRedraws();

            decimal credits = AwardCredits(Player);
            CurrentDialogue = $"{Player.Hand.PokerHand.ToReadableString()}! You were awarded {credits} credits.";

            CurrentDiscardIndices.Clear();
        }

        public void InitializeGameState()
        {
            CurrentState = GameState.Deal;
            OnGameStateChange?.Invoke();
        }

        public void AdvanceGameState()
        {
            GameState[] gameStates = Enum.GetValues<GameState>();
            CurrentState = gameStates[((int)CurrentState + 1) % gameStates.Length];

            OnGameStateChange?.Invoke();
        }

        public void AcceptRedraws()
        {
            foreach (int index in CurrentDiscardIndices)
            {
                Player.Hand[index] = Dealer.DealCard();
            }
        }

        public decimal AwardCredits(Player player)
        {
            decimal credits = (int)(CurrentBet * PokerHandMultipliers[player.Hand.PokerHand]);

            player.Balance += credits;
            return credits;
        }
    }
}
