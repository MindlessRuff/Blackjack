using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    
    /// <summary>
    /// This class will handle the player and dealer hands as well as the Hit, Stand, DoubleDown, Split, and Surrender methods
    /// </summary>
    class Blackjack : IComparable<Blackjack>
    {
        Deck newDeck = new Deck();
        GambleChips chips = new GambleChips();
        public Strategy newHint = new Strategy();
        public Player player = new Player();
        private Player dealer = new Player();
        bool hit { get; set; }
        bool stand { get; set; }
        bool doubleDown { get; set; }
        public bool busted { get; set; }    // Variable will be set when playerHand > 21, only UI class will reset this variable.

        /// <summary>
        /// This constructor will shuffle the deck, deal cards to the dealer and player, and display the values in the 
        /// debug console for testing
        /// </summary>
        public Blackjack()
        {
            // create new deck object first            
            // Shuffle the deck and generate the stack
            newDeck.Shuffle_Deck();
            
            // Deal the cards to the player and the dealer
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());

            // Print the game state to the Debug Console
            System.Diagnostics.Debug.Write(this.ToString());
        }    
        /// <summary>
        /// 
        /// </summary>
        public void Hit()
        {
            // TODO: add logic to check for bust            
            player.AddCard(newDeck.Deal_Card());

            // Print the Hands out
            System.Diagnostics.Debug.Write(player.ToString());

            if (player.handValue > 21)
            {
                busted = true;
                
            }
        }

        public void Stand()
        {
            System.Diagnostics.Debug.Write(player.ToString());
        }

        public void DoubleDown()
        {
            //Implment the chips being doubled 
            player.AddCard(newDeck.Deal_Card());
            Stand();
        }

        public int Split()
        {
            throw new NotImplementedException();
        }

        public void Surrender()
        {
            //Here the player losses half their bet 
            NextRound();
        }

        /// <summary>
        /// Copy of the contructor for creating a new game, although this method will not shuffle the deck
        /// until there no cards remaining
        /// </summary>
        public void NextRound()
        {
            if (newDeck.CardsInStack() < 10)
                newDeck.Shuffle_Deck();
            
            // Reset cards in hand and value of hands.
            player.playerHand.Clear();
            dealer.playerHand.Clear();
            player.handValue = 0;
            dealer.handValue = 0;

            // Deal the cards to the player and the dealer

            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());

            // Print the game state to the Debug Console
            System.Diagnostics.Debug.Write(this.ToString());
            busted = false;  // Reset busted flag.
        }

        public int CompareTo(Blackjack other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string gameState = "Player Hand: \n" +
                $"{player.ToString()}\n" +
                $"Dealer Hand: \n" +
                $"{dealer.ToString()}\n";
            return gameState;            
        }

        public string Hints()
        {
            string hint = "";
            hint = newHint.Hints(player.playerHand[0], player.playerHand[1], dealer.playerHand[1]);
            return hint;
        }
    }
}
