using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Strategy : IComparable<Strategy>
    {
        private List<string> playerCards = new List<string>();
        private string dealerCard { get; set; }

        public Strategy() { }

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
        public string Hints(string playerC0, string playerC1, string dealerC1)
        {
            playerCards.Add(playerC0);
            playerCards.Add(playerC1);
            dealerCard = dealerC1;
            string hint = "";

            //List of double down strategies 
            //First to handle all the cases for 11
            //First card is a 9 second card is a 2
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '2'))
            {
                hint = "Hint: Doubledown";
            }

            //First card is a 2 second card is a 9
            if ((playerCards[0][7] == '2' && playerCards[1][7] == '9'))
            {
                hint = "Hint: Doubledown";
            }

            //first card is a 8 second card is a 3
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '3'))
            {
                hint = "Hint: Doubledown";
            }

            //First card is a 3 second card is a 8
            if ((playerCards[0][7] == '3' && playerCards[1][7] == '8'))
            {
                hint = "Hint: Doubledown";
            }

            //first card is a 7 second card is a 4
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '4'))
            {
                hint = "Hint: Doubledown";
            }

            //First card is a 4 second card is a 7
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '7'))
            {
                hint = "Hint: Doubledown";
            }

            //first card is a 5 second card is a 6
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '8'))
            {
                hint = "Hint: Doubledown";
            }

            //First card is a 6 second card is a 5
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '5'))
            { 
                hint = "Hint: Doubledown";
            }

            playerCards.Clear();
            return hint;
        }

        public int CompareTo(Strategy other)
        {
            throw new NotImplementedException();
        }
    }
}
