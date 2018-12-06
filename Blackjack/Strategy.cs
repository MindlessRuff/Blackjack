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
        private string dealerCard = "";

        public Strategy()
        {
            //string strategy = "";

            //if (player.handValue < 17 && dealer.handValue >= 17)
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

            //else if (player.handValue == 17)
            //{
            //    strategy = "Book says to stand";
            //}

            //else if (player.handValue >= 12 && player.handValue <= 16 && dealer.handValue >= 4 && dealer.handValue <= 6)
            //{
            //    strategy = "Book says to stand";
            //}
            //Implement if, else-if statements
            //Or cases...

           // return strategy;
        }

        public Strategy(List<string> cards, string shownCard)
        {
            playerCards = cards;
            dealerCard = shownCard;
        }
        public int CompareTo(Strategy other)
        {
            throw new NotImplementedException();
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
        public string Tips()
        {
            string tip = "";

            //if (player.handValue < 17 && dealer.handValue >= 17)
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

            return tip;
        }
    }
}
