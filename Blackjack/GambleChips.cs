using System;

namespace Blackjack
{
    internal class GambleChips : IComparable<GambleChips>
    {
        public int playerChips { get; set; }

        public int CompareTo(GambleChips other)
        {
            throw new NotImplementedException();
        }

        public GambleChips()
        {
            playerChips = 500; //$500
        }

        public void DoubleChips(int doubleBet)
        {
            playerChips += (doubleBet * 2);
            // TODO: Algorithm and code to add up total chips won

            /*if (userBet == OneDollarChip)
            {
                DoubleOneDollarBet = userBet * 2;
                return DoubleOneDollarBet;
            }
            else if (userBet == FiveDollarChip)
            {
                DoubleFiftyDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else if (userBet == TwentyFiveDollarChip )
            {
                DoubleTwentyFiveDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else if (userBet == FiftyDollarChip)
            {
                DoubleFiftyDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else
            {
                return 0;
            }
            */

            //return 0;
            
        }

        public void WinDoubleDown (int doubleDownChips)
        {
            playerChips += (doubleDownChips * 2);
        }

        public int LoseChips()
        {
            // TODO: Algorithm and code the losses of chips
            return 0;
        }

        public void surrenderChips(int divideChips)
        {
            playerChips /= (divideChips / 2);
            // TODO: Algorithm and code the losses 
            /*if (userBet == OneDollarChip)
            {
                DoubleOneDollarBet = userBet * 2;
                return DoubleOneDollarBet;
            }
            else if (userBet == FiveDollarChip)
            {
                DoubleFiftyDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else if (userBet == TwentyFiveDollarChip )
            {
                DoubleTwentyFiveDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else if (userBet == FiftyDollarChip)
            {
                DoubleFiftyDollarBet = userBet * 2;
                return DoubleFiftyDollarBet;
            }
            else
            {
                return 0;
            }
            */

            //surrendingHand = userBet / 2;
            //return surrendingHand;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}