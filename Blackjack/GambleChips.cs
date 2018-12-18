using System;

namespace Blackjack
{
    internal class GambleChips : IComparable<GambleChips>
    {
        public int playerChips { get; set; }


        public GambleChips()
        {
            playerChips = 500; //Start player with $500
        }

        public int CompareTo(GambleChips other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bet"></param>
        public void DeductChips(int bet)
        {
            playerChips = playerChips - bet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bet"></param>
        public void DoubleChips(int bet)
        {
            playerChips = playerChips + (2 * bet); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bet"></param>
        public void Surrendered(int bet)
        {
            playerChips = playerChips + (bet / 2);
        }
    }
}