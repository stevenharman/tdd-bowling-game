using System;
using System.Collections;

namespace Bowling
{
	public class BowlingGame
	{
		private Frame firstFrame = null;
		private Frame lastFrame = null;

		public BowlingGame()
		{
		
		}

		private void AddFrame(Frame frame)
		{
			if(firstFrame == null) 
			{
				frame.Number = 1;
				firstFrame = frame;
				lastFrame = frame;
			}
			else
			{
				if(lastFrame.Number == 10)
				{
					throw new OutOfFramesException();
				}
				frame.Number = lastFrame.Number + 1;
				lastFrame.NextFrame = frame;
				lastFrame = frame;
			}
		}

		public void RollFrame(int roll1, int roll2)
		{
			AddFrame(new Frame(roll1, roll2));
		}

		public void RollSpare(int roll1, int roll2) 
		{
			Spare spare = new Spare(roll1, roll2);
			AddFrame(spare);
		}

		public void RollStrike()
		{
			Strike strike = new Strike();
			AddFrame(strike);
		}

		public void RollTenthFrame(int roll1, int roll2, int roll3)
		{
			Frame frame = new Frame(roll1, roll2);
			frame.BonusRoll = roll3;
			AddFrame(frame);
		}

		public int Score
		{
			get
			{
				int score = 0;
				Frame currentFrame = firstFrame;
				while(currentFrame != null)
				{
					score += currentFrame.TotalRoll;
					if(currentFrame.IsSpare)
					{
						score += currentFrame.NextFrame.Roll1;
					}
					else if (currentFrame.IsStrike)
					{
						score += currentFrame.NextFrame.Roll1;
						if(currentFrame.NextFrame.IsStrike)
						{
							score += currentFrame.NextFrame.NextFrame.Roll1;
						}
						else
						{
							score += currentFrame.NextFrame.Roll2;
						}
					}

					currentFrame = currentFrame.NextFrame;
				}

				return score;
			}
		}
	}
}
