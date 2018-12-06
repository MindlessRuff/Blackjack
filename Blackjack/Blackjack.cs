using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //test
    /// <summary>
    /// This class will handle the player and dealer hands as well as the Hit, Stand, DoubleDown, Split, and Surrender methods
    /// </summary>
    class Blackjack : IComparable<Blackjack>
    {
        Deck newDeck = new Deck();
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
        /*
            playerHand.Add(newDeck.Deal_Card());
            dealerHand.Add(newDeck.Deal_Card());
            playerHand.Add(newDeck.Deal_Card());
            dealerHand.Add(newDeck.Deal_Card());

            // Add their values
            playerHandValue += Card_Value(playerHand[0]);
            playerHandValue += Card_Value(playerHand[1]);
            dealerHandValue += Card_Value(dealerHand[0]);
            dealerHandValue += Card_Value(dealerHand[1]);
            */
            
        


        /// <summary>
        /// 
        /// </summary>
        public void Hit()
        {

            // TODO: add logic to check for bust            
            player.AddCard(newDeck.Deal_Card());

            // Print the Hands out
            System.Diagnostics.Debug.Write(player.ToString());

            // Testing out the values of each card in the list of handVals.
            // First two cards in hand will determine which strategy to provide to the player.
            System.Diagnostics.Debug.WriteLine(player.handVals[0].ToString());
            System.Diagnostics.Debug.WriteLine(player.handVals[1].ToString());
            System.Diagnostics.Debug.WriteLine(dealer.handVals[0].ToString());
            System.Diagnostics.Debug.WriteLine(dealer.handVals[1].ToString());

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
            player.AddCard(newDeck.Deal_Card());
            Stand();
        }

        public int Split()
        {
            throw new NotImplementedException();
        }

        public int Surrender()
        {
            //Here the player losses half their bet 
            return 0;
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

        public override string ToString()
        {
            string gameState = "Player Hand: \n" +
                $"{player.ToString()}\n" +
                $"Dealer Hand: \n" +
                $"{dealer.ToString()}\n";
            return gameState;            
        }

        /// <summary>
        /// List of basic strategy to guide the player in their decision.
        /// This method strictly utilizes the first two cards in the list of 'handVals'
        /// to determine which strategy to provide to the player.
        /// 
        /// Strategy Reference: https://www.blackjackapprenticeship.com/blackjack-strategy-charts/
        /// Feel free to change this method of strategy if you feel that there is a better approach.
        /// 
        /// </summary>
        /// <returns></returns>
        public string Strategy()
        {
            string strategy = "";

            if (player.handValue < 17 && dealer.handValue >= 17)
            {
                strategy = "Book says to hit";
            }

            else if (player.handValue == 11)
            {
                strategy = "Book says to double down";
            }

            else if (player.handValue >= 9 && player.handValue <= 11 && dealer.handValue == 5 || dealer.handValue == 6)
            {
                strategy = "Book says to double down";
            }
            //Implement if, else-if statements
            //Or cases...
        
            return strategy;
        }
    }
}
