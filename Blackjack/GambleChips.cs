﻿using System;

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

        




        public int CompareTo(GambleChips other)
        {
            throw new NotImplementedException();
        }

        public int DoubleChips()
        {
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

            return 0;
            
        }

        public int LossChips()
        {
            // TODO: Algorithm and code the losses of chips
            return 0;
        }

        public int surrenderChips()
        {
            // TODO: Algorithm and code the losses 
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
    }
}