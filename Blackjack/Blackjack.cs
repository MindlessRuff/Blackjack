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
        public Player split = new Player();
        public Player dealer = new Player();
        bool hit { get; set; }
        bool stand { get; set; }
        bool doubleDown { get; set; }

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
            if (player.handValue == 21) player.naturalBlackjack = true;
            if (dealer.handValue == 21) dealer.naturalBlackjack = true;

            // Print the game state to the Debug Console
            System.Diagnostics.Debug.Write(this.ToString());
        }    

        /// <summary>
        /// 
        /// </summary>
        public void Hit(Player hitPlayer)
        {          
            hitPlayer.AddCard(newDeck.Deal_Card());
           

            // Check for bust.
            if (hitPlayer.handValue > 21)
            {
                // If player will bust, but there is an ace (11) in hand, subtract 10.
                if (hitPlayer.numElevens > 0)
                {
                    hitPlayer.numElevens -= 1;
                    hitPlayer.handValue -= 10;
                }
                else
                {
                    hitPlayer.busted = true;
                }     
            }
        }

        /// <summary>
        /// Function is called when user stands, initiating the dealer logic.
        /// Dealer will always hit if handValue is less than 17.
        /// Dealer also hits on a "soft" 17.
        /// </summary>
        public void Stand()
        {
            // If dealer has naturalBlackjack after user stands, dealer wins. Control is passed back to UI.
            if (dealer.naturalBlackjack) return;

            // Dealer hit block.
            while ((dealer.handValue < 17 || dealer.numElevens > 0) && dealer.handValue != 21)
            {
                dealer.AddCard(newDeck.Deal_Card());
                // Check for under 17 or soft > 17.
                if (dealer.numElevens > 0 && dealer.handValue >= 17 && dealer.handValue != 21)
                {
                    dealer.numElevens -= 1;
                    dealer.numOnes += 1;
                    dealer.handValue -= 10;
                }
            }
            // Dealer busts
            if (dealer.handValue > 21)
            {
                dealer.busted = true;
            }
            return;
        }

        public void DoubleDown()
        {
            //Implment the chips being doubled 
            player.AddCard(newDeck.Deal_Card());
            chips.DoubleChips();
            Stand();
        }

        public void Split()
        {
            bool hit = true;
            do
            {
                Hit(player);

            } while (hit == true);
            
            player.AddCard(newDeck.Deal_Card());  // Add card to first split hand.

            // Check for bust.
            if (player.handValue > 21)
            {
                // If player will bust, but there is an ace (11) in hand, subtract 10.
                if (player.numElevens > 0)
                {
                    player.numElevens -= 1;
                    player.handValue -= 10;
                }
                else
                {
                    player.busted = true;
                }
            }
           
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
            {
                newDeck.Shuffle_Deck();
            }
                
            // Reset all player and dealer variables.
            player.Reset();
            dealer.Reset();

            // Deal the cards to the player and the dealer

            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            if (player.handValue == 21) player.naturalBlackjack = true;
            if (dealer.handValue == 21) dealer.naturalBlackjack = true;

            // Print the game state to the Debug Console
            System.Diagnostics.Debug.Write(this.ToString());
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
            hint = newHint.Hints(player.hand[0], player.hand[1], dealer.hand[1]);
            return hint;
        }
    }
}
