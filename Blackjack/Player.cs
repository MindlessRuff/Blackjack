using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack;
using System.ComponentModel;
namespace Blackjack
{
    class Player : IComparable<Player>
    {
        public int handValue { get; set; }
        public List<string> hand = new List<string>();  // Cards are stored as strings representing their filepaths for UI binding.
        public int numElevens { get; set; }             // numElevens tracks how many aces are assigned a value of 11 for hand value updating.
        public bool busted { get; set; }                // Variable will be set when hand > 21, only UI class will reset this variable.
        public bool naturalBlackjack { get; set; }      // Tracks 21 on deal, which is higher than other 21's. Set in blackjack class.
        public int numOnes { get; set; }                // Tracks number of soft aces, used in UI stand function to correct dealer UI hand value representation.


        //Explicit public constructor
        public Player()
        {
            handValue = 0;
            numElevens = 0;
            naturalBlackjack = false;
            busted = false;
        }

        public void AddCard(string card)
        {
            hand.Add(card);
            int temp = Card_Value(card);
            if (temp == 11)
            {
                numElevens += 1;                 // Update number of elevens in hand to update logic in case of > 21.
            }
            handValue += temp;
        }

        public string Total_Value()
        {
            string totalValue = "";
            totalValue =  $"Total value of cards: {handValue} \n";
            return totalValue;
        }

        /// <summary>
        /// dealt_Card's 7th index (the value) is converted to char 
        /// and analyzed to return the correct integer value
        /// </summary>
        /// <param name="dealt_Card"></param>
        /// <returns></returns>
        public int Card_Value(string dealt_Card)
        {
            // Extract value into char
            char rank = dealt_Card[7];
            if (rank >= '2' && rank <= '9')
            {
                return rank - '0';
            }
            // Ace Logic
            else if (rank == 'A')
            {
                if (handValue > 10) return 1;
                else
                {
                    return 11;
                }
            }
            // 10, J, Q, K will return 10.
            else return 10;
        }

        /// <summary>
        /// Reset all player variables (Cards, handValue, etc)
        /// Called for each new round.
        /// </summary>
        public void Reset()
        {
            hand.Clear();
            handValue = 0;
            numElevens = 0;
            busted = false;
            naturalBlackjack = false;
        }

        public int CompareTo(Player other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string printedHand = "";
            foreach (string s in hand)
            {
                printedHand += s + "\n";
            }
            printedHand += Total_Value();
            return printedHand;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
