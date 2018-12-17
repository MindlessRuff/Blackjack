using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class Strategy    // Declared as static to avoid needing to create an instance to use hints method
    {
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
        public static string Hints(string playerC0, string playerC1, string dealerC1)
        {
            List<string> playerCards = new List<string>();
            string dealerCard;

            playerCards.Add(playerC0);
            playerCards.Add(playerC1);
            dealerCard = dealerC1;

            string hint = "";

            //List of double down strategies 
            //First to handle all the cases for 11
            //First card is a 9 second card is a 2
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '2'))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 2 second card is a 9
            if ((playerCards[0][7] == '2' && playerCards[1][7] == '9'))
            {
                hint = "Book Says to Doubledown";
            }

            //first card is a 8 second card is a 3
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '3'))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 3 second card is a 8
            if ((playerCards[0][7] == '3' && playerCards[1][7] == '8'))
            {
                hint = "Book Says to Doubledown";
            }

            //first card is a 7 second card is a 4
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '4'))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 4 second card is a 7
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '7'))
            {
                hint = "Book Says to Doubledown";
            }

            //first card is a 5 second card is a 6
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '6'))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 6 second card is a 5
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '5'))
            {
                hint = "Book Says to Doubledown";
            }


            //Cases for all 10's 

            //First card is a 5 and second card is a 5
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '5' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' 
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 6 and second card is a 4
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '4' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 4 and second card is a 6
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '6' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 7 and second card is a 3
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '3' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 3 and second card is a 7
            if ((playerCards[0][7] == '3' && playerCards[1][7] == '7' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 8 and second card is a 2
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '2' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 2 and second card is a 8
            if ((playerCards[0][7] == '2' && playerCards[1][7] == '8' && (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4'
                || dealerCard[7] == '5' || dealerCard[7] == '6' || dealerCard[7] == '7' || dealerCard[7] == '8' || dealerCard[7] == '9')))
            {
                hint = "Book Says to Doubledown";
            }

            //Cases for all the 9 double downs

            //First card is a 4 and second card is a 5
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '5' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 5 and second card is a 4
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '4' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 6 and second card is a 3
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '3' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 3 and second card is a 6
            if ((playerCards[0][7] == '3' && playerCards[1][7] == '6' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 7 and second card is a 2
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '2' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //First card is a 2 and second card is a 7
            if ((playerCards[0][7] == '2' && playerCards[1][7] == '7' && (dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5'
                || dealerCard[7] == '6')))
            {
                hint = "Book Says to Doubledown";
            }

            //Strats for all stands

            //Sum of 17: First card 10 second card 7
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '7' )
            {
                hint = "Book Says to Stand";
            }

            //Sum of 17: First card 7 second card 10
            if (playerCards[0][7] == '7' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 17: First Card 9 second card 8
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '8'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 17: First card 8 second card 9
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '9'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 16: First card 10 second card 6
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '6' && 
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 16: First card 6 second card 10
            if (playerCards[0][7] == '6' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
                
            {
                hint = "Book Says to Stand";
            }

            //Sum of 16: First Card 9 second card 7
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '7' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 16: First card 7 second card 9
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 16: First Card 8 second card 8
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '8' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First card 10 second card 5
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '5' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First card 5 second card 10
            if (playerCards[0][7] == '5' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))

            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First Card 9 second card 6
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '6' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First card 6 second card 9
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First Card 7 second card 8
            if ((playerCards[0][7] == '7' && playerCards[1][7] == '8' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 15: First card 8 second card 7
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '7' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First card 10 second card 4
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '4' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First card 4 second card 10
            if (playerCards[0][7] == '4' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))

            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First Card 9 second card 5
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '5' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First card 5 second card 9
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First Card 8 second card 6
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '6' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 14: First card 6 second card 8
            if ((playerCards[0][7] == '6' && playerCards[1][7] == '8' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First card 10 second card 3
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '3' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First card 3 second card 10
            if (playerCards[0][7] == '3' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))

            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First Card 9 second card 4
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '4' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First card 4 second card 9
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First Card 8 second card 5
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '5' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 13: First card 5 second card 8
            if ((playerCards[0][7] == '5' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '2' || dealerCard[7] == '3' || dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First Card 10 second card 2
            if ((playerCards[0][7] == 'T' || playerCards[0][7] == 'J' || playerCards[0][7] == 'Q' || playerCards[0][7] == 'K') && playerCards[1][7] == '2' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6'))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First card 2 second card 10
            if (playerCards[0][7] == '2' && (playerCards[1][7] == 'T' || playerCards[1][7] == 'J' || playerCards[1][7] == 'Q' || playerCards[1][7] == 'K' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))

            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First Card 9 second card 3
            if ((playerCards[0][7] == '9' && playerCards[1][7] == '3' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First card 3 second card 9
            if ((playerCards[0][7] == '3' && playerCards[1][7] == '9' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First Card 8 second card 4
            if ((playerCards[0][7] == '8' && playerCards[1][7] == '4' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }

            //Sum of 12: First card 4 second card 8
            if ((playerCards[0][7] == '4' && playerCards[1][7] == '8' &&
                (dealerCard[7] == '4' || dealerCard[7] == '5' || dealerCard[7] == '6')))
            {
                hint = "Book Says to Stand";
            }


            //Cases for all the hits

            //For a hand total of 4,5,6,7, or 8
            //First card is a 2 and second card is a 2
            if (playerCards[0][7] == '2' && playerCards[1][7] == '2')
            {
                hint = "Book Says to Hit";
            }

            //First card is a 2 and second card is a 3
            if (playerCards[0][7] == '2' && playerCards[1][7] == '3')
            {
                hint = "Book Says to Hit";
            }

            //First card is a 3 and second card is a 2
            if (playerCards[0][7] == '3' && playerCards[1][7] == '2')
            {
                hint = "Book Says to Hit";
            }

            //First card is a 3 and second card is a 3
            if (playerCards[0][7] == '3' && playerCards[1][7] == '3')
            {
                hint = "Book Says to Hit";
            }

            //First card is a 4 and second card is a 2
            if (playerCards[0][7] == '4' && playerCards[1][7] == '2')
            {
                hint = "Book Says to Hit";
            }

            //First card is a 2 and second card is a 4
            if (playerCards[0][7] == '2' && playerCards[1][7] == '4')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 7
            //First card is a 4 and second card is a 3
            if (playerCards[0][7] == '4' && playerCards[1][7] == '3')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 7
            //First card is a 3 and second card is a 4
            if (playerCards[0][7] == '3' && playerCards[1][7] == '4')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 7
            //First card is a 5 and second card is a 2
            if (playerCards[0][7] == '5' && playerCards[1][7] == '2')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 7
            //First card is a 2 and second card is a 5
            if (playerCards[0][7] == '2' && playerCards[1][7] == '5')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 8
            //First card is a 4 and second card is a 4
            if (playerCards[0][7] == '4' && playerCards[1][7] == '4')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 8
            //First card is a 6 and second card is a 2
            if (playerCards[0][7] == '6' && playerCards[1][7] == '2')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 8
            //First card is a 2 and second card is a 6
            if (playerCards[0][7] == '2' && playerCards[1][7] == '6')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 8
            //First card is a 5 and second card is a 3
            if (playerCards[0][7] == '5' && playerCards[1][7] == '3')
            {
                hint = "Book Says to Hit";
            }

            //Sum = 8
            //First card is a 3 and second card is a 5
            if (playerCards[0][7] == '3' && playerCards[1][7] == '5')
            {
                hint = "Book Says to Hit";
            }

            else
            {
                hint = "No Suggested Strategy";
            }

            playerCards.Clear();
            return hint;
        }
    }
}
