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

        public Player player = new Player();
        public Player splitPlayer = new Player();
        public Player dealer = new Player();
        bool doubleDown { get; set; }
        public bool split { get; set; }
        public bool stand { get; set; }     // Used when the left side of a split hand stands.
        // Bind "playerBet" to UI chip to allow the user to set the number of chips he/she would like to bet.
        public int playerBet { get; set; }  // playerBet will be passed as a parameter to the methods inside of the GambleChips class.


        /// <summary>
        /// This constructor will shuffle the deck, deal cards to the dealer and player.
        /// </summary>
        public Blackjack()
        {
            // create new deck object first            
            // Shuffle the deck and generate the stack
            newDeck.Shuffle_Deck();

            // Deal the cards to the player and the dealer

            NextRound();
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
                chips.DoubleChips(playerBet);
            }
            return;
        }

        public void DoubleDown()
        {
            //TODO:Implment the chips being doubled
            //Deduct the previously betted value (doubling the bet)
            chips.DeductChips(playerBet);
            //Double the amount of bet
            playerBet = playerBet * 2;
            player.AddCard(newDeck.Deal_Card());
            Stand();
        }

        public void Split()
        {
            split = true;
            player.numElevens = 0;
            // Divide the cards between player and splitPlayer hands. -> Set player handvalue equal to first card only.
            splitPlayer.AddCard(player.hand[1]);
            player.hand.RemoveAt(1);
            player.handValue = player.Card_Value(player.hand[0]);
            // Fix ace logic
            if (player.hand[0][7] == 'A')
            {
                player.handValue = 11;
                player.numElevens += 1;
                splitPlayer.handValue = 11;
                splitPlayer.numElevens += 1;
            }
            player.AddCard(newDeck.Deal_Card());        // Add card to first hand.
            splitPlayer.AddCard(newDeck.Deal_Card());   // Add card to split hand, will not show in UI hand until first hand stands or busts.

        }    

        public void Surrender()
        {
            //Here the player losses half their bet 
            chips.Surrendered(playerBet);
            NextRound();
        }

        // Called at the end of dealer's turn to calculate the winner and output message to UI.
        public string CalculateWinner()
        {
            // Hand was split
            if (split)
            {
                if ((dealer.busted && !player.busted && !splitPlayer.busted) || ((player.handValue > dealer.handValue && !player.busted) &&
                    (splitPlayer.handValue > dealer.handValue && !splitPlayer.busted))) return "Both Hands Win!";
                else if (!dealer.busted && (player.busted && (splitPlayer.busted || splitPlayer.handValue < dealer.handValue)) ||
                    (player.handValue < dealer.handValue && splitPlayer.busted) ||
                    (player.handValue < dealer.handValue && splitPlayer.handValue < dealer.handValue)) return "Both Hands Lose!";

                // Cases with 1.5x payout due to one push and one win.
                else if ((player.handValue > dealer.handValue && !dealer.busted && splitPlayer.handValue == dealer.handValue) ||
                    (splitPlayer.busted && dealer.busted && !player.busted)) return "Win + Push, 1.5x Payout";
                else if ((splitPlayer.handValue > dealer.handValue && !dealer.busted && player.handValue == dealer.handValue) ||
                    (player.busted && dealer.busted && !splitPlayer.busted)) return "Push + Win, 1.5x Payout";

                // Cases with 0.5x payout due to one push and one loss.
                else if (!dealer.busted && splitPlayer.handValue == dealer.handValue && 
                    (player.handValue < dealer.handValue || player.busted)) return "Lose + Push, 0.5x Payout";
                else if (!dealer.busted && player.handValue == dealer.handValue &&
                    (splitPlayer.handValue < dealer.handValue || splitPlayer.busted)) return "Push + Lose, 0.5x Payout";

                else return "Push"; // The case in which one hand wins and the other loses, or both hands tie the dealer.
            }
            else
            {
                if (player.handValue > dealer.handValue || dealer.handValue > 21) return "You Win!";
                else if (player.handValue < dealer.handValue && dealer.handValue <= 21) return "You Lose!";
                else return "Push!";
            }
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
            splitPlayer.Reset();
            split = false;
            stand = false;
            
            //TODO: set the value of the playerBet through UI and then call the chip deduction method to deduce
            //      the player's chips so that it stays up to date after bets/ winnings

            // Deal the cards to the player and the dealer
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            player.AddCard(newDeck.Deal_Card());
            dealer.AddCard(newDeck.Deal_Card());
            if (player.handValue == 21) player.naturalBlackjack = true;
            if (dealer.handValue == 21) dealer.naturalBlackjack = true;
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
                $"{dealer.ToString()}\n" +
                $"Split Hand: \n" +
                $"{splitPlayer.ToString()}\n";
            return gameState;            
        }

    }
}
