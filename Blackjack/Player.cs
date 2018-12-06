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

        private int cardVal = 0;

        //Explicit public constructor
        public Player()
        {
            handValue = 0;
        }

        public void PlayerHandValue(int value)
        {
            handValue += value;
        }

        public void AddCard(string card)
        {
            playerHand.Add(card);
            PlayerHandValue(Card_Value(card));
        }

        public string Total_Value()
        {
            return $"Total value of cards: {handValue}";
        }

        /// <summary>
        /// dealt_Card value is determined via case statements
        /// and the determined value is returned as type int.
        /// </summary>
        /// <param name="dealt_Card"></param>
        /// <returns></returns>
        public int Card_Value(string dealt_Card)
        {

            // TODO: Figure out how to add logic for Ace value
            switch (dealt_Card)
            {
                case "Assets/2_C.png":
                case "Assets/2_D.png":
                case "Assets/2_H.png":
                case "Assets/2_S.png":
                    cardVal = 2;
                    break;
                case "Assets/3_C.png":
                case "Assets/3_D.png":
                case "Assets/3_H.png":
                case "Assets/3_S.png":
                    cardVal = 3;
                    break;
                case "Assets/4_C.png":
                case "Assets/4_D.png":
                case "Assets/4_H.png":
                case "Assets/4_S.png":
                    cardVal = 4;
                    break;
                case "Assets/5_C.png":
                case "Assets/5_D.png":
                case "Assets/5_H.png":
                case "Assets/5_S.png":
                    cardVal = 5;
                    break;
                case "Assets/6_C.png":
                case "Assets/6_D.png":
                case "Assets/6_H.png":
                case "Assets/6_S.png":
                    cardVal = 6;
                    break;
                case "Assets/7_C.png":
                case "Assets/7_D.png":
                case "Assets/7_H.png":
                case "Assets/7_S.png":
                    cardVal = 7;
                    break;
                case "Assets/8_C.png":
                case "Assets/8_D.png":
                case "Assets/8_H.png":
                case "Assets/8_S.png":
                    cardVal = 8;
                    break;
                case "Assets/9_C.png":
                case "Assets/9_D.png":
                case "Assets/9_H.png":
                case "Assets/9_S.png":
                    cardVal = 9;
                    break;
                case "Assets/T_C.png":
                case "Assets/T_D.png":
                case "Assets/T_H.png":
                case "Assets/T_S.png":
                case "Assets/J_C.png":
                case "Assets/J_D.png":
                case "Assets/J_H.png":
                case "Assets/J_S.png":
                case "Assets/Q_C.png":
                case "Assets/Q_D.png":
                case "Assets/Q_H.png":
                case "Assets/Q_S.png":
                case "Assets/K_C.png":
                case "Assets/K_D.png":
                case "Assets/K_H.png":
                case "Assets/K_S.png":
                    cardVal = 10;
                    break;
                case "Assets/A_C.png":
                case "Assets/A_D.png":
                case "Assets/A_H.png":
                case "Assets/A_S.png":
                    if (handValue > 10)
                        cardVal = 1;
                    else
                    cardVal = 11;
                    break;
            }
            return cardVal;
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
                printedHand += s;
                printedHand += "\n";
            }

            printedHand += Total_Value();

            return printedHand;
        }
    }
}
