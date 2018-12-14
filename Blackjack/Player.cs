using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player : IComparable<Player>
    {
        public int handValue { get; set; }
        public List<string> hand = new List<string>();  // Cards are stored as strings representing their filepaths for UI binding.
        public int numElevens = 0;                      // numElevens tracks how many aces are assigned a value of 11 for hand value updating.

        //Explicit public constructor
        public Player()
        {
            handValue = 0;
        }

        public void AddCard(string card)
        {
            hand.Add(card);
            handValue += Card_Value(card);
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
                    numElevens += 1;        // Update number of elevens in hand to update logic in case of > 21.
                    return 11;
                }
            }
            // 10, J, Q, K will return 10.
            else return 10;
        }

        /// <summary>
        /// Reset cards in hand, value of hand, and number of elevens.
        /// Called for each new round.
        /// </summary>
        public void Reset()
        {
            handValue = 0;
            hand.Clear();
            numElevens = 0;
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
