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
            if (playerCards[0] == "Assets/A_C.png" && playerCards[1] == "Assets/T_C.png" && dealerCard == "Assets/5_C.png")
            {
                hint = "Tip: Doubledown";
            }

            //First card is a 9 second card is a 2
            if ((playerCards[0] == "Assets/9_C.png" || playerCards[0] == "Assets/9_D.png" || playerCards[0] == "Assets/9_S.png" || playerCards[0] == "Assets/9_H.png" ) &&
                (playerCards[1] == "Assets/2_C.png" || playerCards[1] == "Assets/2_D.png" || playerCards[1] == "Assets/2_S.png" || playerCards[1] == "Assets/2_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //First card is a 2 second card is a 9
            if ((playerCards[0] == "Assets/9_C.png" || playerCards[0] == "Assets/9_D.png" || playerCards[0] == "Assets/9_S.png" || playerCards[0] == "Assets/9_H.png" ) &&
                (playerCards[1] == "Assets/2_C.png" || playerCards[1] == "Assets/2_D.png" || playerCards[1] == "Assets/2_S.png" || playerCards[1] == "Assets/2_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //first card is a 8 second card is a 3
            if ((playerCards[0] == "Assets/8_C.png" || playerCards[0] == "Assets/8_D.png" || playerCards[0] == "Assets/8_S.png" || playerCards[0] == "Assets/8_H.png" ) &&
                (playerCards[1] == "Assets/3_C.png" || playerCards[1] == "Assets/3_D.png" || playerCards[1] == "Assets/3_S.png" || playerCards[1] == "Assets/3_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //First card is a 3 second card is a 8
            if ((playerCards[0] == "Assets/3_C.png" || playerCards[0] == "Assets/3_D.png" || playerCards[0] == "Assets/3_S.png" || playerCards[0] == "Assets/3_H.png" ) &&
                (playerCards[1] == "Assets/8_C.png" || playerCards[1] == "Assets/8_D.png" || playerCards[1] == "Assets/8_S.png" || playerCards[1] == "Assets/8_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //first card is a 7 second card is a 4
            if ((playerCards[0] == "Assets/7_C.png" || playerCards[0] == "Assets/7_D.png" || playerCards[0] == "Assets/7_S.png" || playerCards[0] == "Assets/7_H.png" ) &&
                (playerCards[1] == "Assets/4_C.png" || playerCards[1] == "Assets/4_D.png" || playerCards[1] == "Assets/4_S.png" || playerCards[1] == "Assets/4_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //First card is a 4 second card is a 7
            if ((playerCards[0] == "Assets/4_C.png" || playerCards[0] == "Assets/4_D.png" || playerCards[0] == "Assets/4_S.png" || playerCards[0] == "Assets/4_H.png" ) &&
                (playerCards[1] == "Assets/7_C.png" || playerCards[1] == "Assets/7_D.png" || playerCards[1] == "Assets/7_S.png" || playerCards[1] == "Assets/7_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //first card is a 5 second card is a 6
            if ((playerCards[0] == "Assets/5_C.png" || playerCards[0] == "Assets/5_D.png" || playerCards[0] == "Assets/5_S.png" || playerCards[0] == "Assets/5_H.png" ) &&
                (playerCards[1] == "Assets/6_C.png" || playerCards[1] == "Assets/6_D.png" || playerCards[1] == "Assets/6_S.png" || playerCards[1] == "Assets/6_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //First card is a 6 second card is a 5
            if ((playerCards[0] == "Assets/6_C.png" || playerCards[0] == "Assets/6_D.png" || playerCards[0] == "Assets/6_S.png" || playerCards[0] == "Assets/6_H.png" ) &&
                (playerCards[1] == "Assets/5_C.png" || playerCards[1] == "Assets/5_D.png" || playerCards[1] == "Assets/5_S.png" || playerCards[1] == "Assets/5_H.png" ))
            {
                hint = "Tip: Doubledown";
            }

            //if (playerCar < 17 && dealer.handValue >= 17)
            //{
            //    strategy = "Book says to hit";
            //}

            //else if (player.handValue == 11)
            //{
            //    strategy = "Book says to double down";
            //}

            //else if (player.handValue >= 9 && player.handValue <= 11 && dealer.handValue == 5 || dealer.handValue == 6)
            //{
            //    strategy = "Book says to double down";
            //}

            playerCards.Clear();
            return hint;
        }

        public int CompareTo(Strategy other)
        {
            throw new NotImplementedException();
        }
    }
}
