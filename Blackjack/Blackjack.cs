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
        public Player dealer = new Player();
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
        public void Hit(Player currentPlayer)
        {          
            currentPlayer.AddCard(newDeck.Deal_Card());

            // Check for bust.
            if (currentPlayer.handValue > 21)
            {
                // If player will bust, but there is an ace (11) in hand, subtract 10.
                if (currentPlayer.numElevens > 0)
                {
                    currentPlayer.numElevens -= 1;
                    currentPlayer.handValue -= 10;
                }
                else
                {
                    busted = true;
                }     
            }
        }

        public void Stand()
        {
            // Dealer hits on anything less than 17, including soft 17
            while (dealer.handValue < 17)
            {
                Hit(dealer);
            }

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
            player.Reset();
            dealer.Reset();

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
            if (other != null)
            {
                if (dealer.handValue >= player.handValue)
                    return 0;
                else
                    return 1;
            }

            return -1;
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
            hint = newHint.Hints(player.hand[0], player.hand[1], dealer.hand[1]);
            return hint;
        }
    }
}
