using System;

namespace Bowling
{
	public class Frame
	{
		protected int roll1;
		protected int roll2;
		protected int bonusRoll;
		protected bool isSpare;
		protected bool isStrike;
		protected Frame nextFrame = null;
		protected int frameNumber = 0;

		public Frame NextFrame
		{
			get{return nextFrame;}
			set{nextFrame = value;}
		}

		public int Number
		{
			get{return frameNumber;}
			set{frameNumber = value;}
		}

		public Frame(int roll1, int roll2)
		{
			this.roll1 = roll1;
			this.roll2 = roll2;
		}

		public int Roll1 { get { return roll1; } }
		public int Roll2 { get { return roll2; } }
		public int BonusRoll 
		{ 
			get { return bonusRoll; } 
			set { bonusRoll = value; }
		}

		public bool IsSpare
		{
			get{return isSpare;}
			set{isSpare = value;}
		}

		public bool IsStrike
		{
			get{return isStrike;}
			set{isStrike = value;}
		}

		public int TotalRoll { get { return roll1 + roll2 + bonusRoll; } }
	}
}
