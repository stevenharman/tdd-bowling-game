using System;

namespace Bowling
{
	public class Strike : Frame
	{
		public Strike() : base(10,0)
		{
			this.isStrike = true;
		}
	}
}
