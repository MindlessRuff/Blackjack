using System;

namespace Blackjack
{
    internal class GambleChips : IComparable<GambleChips>
    {
        private const int OneDollarChip = 1;
        private const int FiveDollarChip = 5;
        private const int TwentyFiveDollarChip = 25;
        private const int FiftyDollarChip = 50;
        private const int HundredDollarChip = 100;
        private int doubledownHand;
        private int losingHand;
        private int surrendingHand;
        private int userBet;

        private int winningHand;

        private int DoubleOneDollarBet;
        private int DoubleFiveDollarBet;
        private int DoubleTwentyFiveDollarBet;
        private int DoubleFiftyDollarBet;
        private int DoubleHundredDollarBet;

        public int playerChips { get; set; }


        public GambleChips()
        {
            playerChips = 500; //Start player with $500
        }
        
        public int CompareTo(GambleChips other)
        {
            throw new NotImplementedException();
        }

        public void DeductChips(int bet)
        {
            playerChips = playerChips - bet;
        }
        public void DoubleChips(int bet)
        {
            playerChips = playerChips + (2 * bet); 
        }
        public void Surrendered(int bet)
        {
            playerChips = playerChips + (bet / 2);
        }
        /*
        public GambleChips()
        {
            playerChips = 500; //$500
        }

        public void DoubleChips(int doubleBet)
        {
            playerChips += (doubleBet * 2);
            // TODO: Algorithm and code to add up total chips won

            userBet = bettingChip;
            doubleBet = userBet * 2;

            return 0;
            
        }
        
        public void WinDoubleDown (int doubleDownChips)
        {
            playerChips += (doubleDownChips * 2);
        }

        public int LoseChips()
        {
            // TODO: Algorithm and code the losses of chips
            lossBet = userBet / 2;
            return lossBet;
        }

        public void surrenderChips(int divideChips)
        {
            // TODO: Algorithm and code the losses 
            if (userBet == OneDollarChip)
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

            surrendingHand = userBet / 2;
            return surrendingHand;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        */
    }
}