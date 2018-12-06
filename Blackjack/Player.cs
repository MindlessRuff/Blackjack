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
        public List<string> playerHand = new List<string>();
        public List<int> handVals = new List<int>();

        //Explicit public constructor
        public Player()
        {
            handValue = 0;
        }

        public void AddCard(string card)
        {
            playerHand.Add(card);
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
                else return 11;
            }
            // 10, J, Q, K will return 10.
            else return 10;
        }

        public int CompareTo(Player other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string printedHand = "";
            foreach (string s in playerHand)
            {
                printedHand += s + "\n";
            }
            printedHand += Total_Value();
            return printedHand;
        }
    }
}
