using System;

namespace Blackjack
{
    internal class GambleChips : IComparable<GambleChips>
    {
        
        private const int bettingChip = 500;
        private int userBet;
        private int doubleBet;
        private int lossBet;




        public int CompareTo(GambleChips other)
        {
            throw new NotImplementedException();
        }

        public int DoubleChips()
        {
            // TODO: Algorithm and code to add up total chips won

            if (userBet == bettingChip)
            {
                doubleBet = userBet * 2;
               
            }

            return doubleBet;
            
        }

        public int LossChips()
        {
            // TODO: Algorithm and code the losses of chips
            lossBet = userBet / 2;
            return lossBet;
        }

        public int surrenderChips()
        {
            return 0;
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