using System;

namespace Bowling.Specs.Infrastructure
{
	public static class HelperExtensions
	{
		public static void times(this int times, Action action)
		{
			for (var i = 0; i < times; i++)
				action();
		}

		public static void times(this int times, Action<int> action)
		{
			for (var i = 0; i < times; i++)
				action(i);
		}
	}
}