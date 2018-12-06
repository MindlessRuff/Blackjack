using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Blackjack
{
	class GambleChips
	{
		private const int OneDollarChip = 1;
		private const int FiveDollarChip = 5;
		private const int TwentyFiveDollarChip = 25;
		private const int FiftyDollarChip = 50;
		private const int HundredDollarChip = 100;

		int winningHand;
		int userBet;
		int losingHand;
		int surrendingHand;
		int doubledownHand;
		
		public int DoubleChips()
		{
			// TODO: Algorithm and code to add up total chips won
			winningHand = userBet * 2;
			return winningHand;
			
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
	
		
	}
}