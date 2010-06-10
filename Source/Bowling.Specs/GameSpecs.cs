using System;
using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			10.times(() => game.RollFrame(0, 0));
		}

		[Specification]
		public void score_is_zero()
		{
			game.Score.should_equal(0);
		}
	}

	public class when_rolling_first_frame_spare_and_rest_two : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			game.RollSpare(2, 8);
			9.times(() => game.RollFrame(2, 2));
		}

		[Specification]
		public void score_is_48()
		{
			game.Score.should_equal(48);
		}
	}

	public class when_rolling_first_two_frames_spare_and_rest_two : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			game.RollSpare(2, 8);
			game.RollSpare(2, 8);
			8.times(() => game.RollFrame(2, 2));
		}

		[Specification]
		public void score_is_56()
		{
			game.Score.should_equal(56);
		}
	}

	public class when_trying_to_bowl_more_than_10_frames : concerns
	{
		private BowlingGame game;
		private readonly Type outOfFramesException = typeof (OutOfFramesException);

		protected override void context()
		{
			game = new BowlingGame();
		}

		[Specification]
		public void throw_out_of_frames_exception()
		{
			outOfFramesException.should_be_thrown_by(
				() => 11.times(() => game.RollFrame(2, 2)));
		}
	}

	public class when_rolling_first_frame_strike_and_rest_two : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			game.RollStrike();
			9.times(() => game.RollFrame(2, 2));
		}

		[Specification]
		public void score_is_50()
		{
			game.Score.should_equal(50);
		}
	}

	public class when_rolling_first_two_frames_strike_and_rest_two : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			game.RollStrike();
			game.RollStrike();
			8.times(() => game.RollFrame(2, 2));
		}

		[Specification]
		public void score_is_68()
		{
			game.Score.should_equal(68);
		}
	}

	public class when_rolling_a_perfect_game : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			9.times(() => game.RollStrike());
			game.RollTenthFrame(10, 10, 10);
		}

		[Specification]
		public void score_is_300()
		{
			game.Score.should_equal(300);
		}
	}

	public class when_rolling_alternate_strikes_and_spares : concerns
	{
		private BowlingGame game;

		protected override void context()
		{
			game = new BowlingGame();
			4.times(() =>
			        	{
			        		game.RollStrike();
			        		game.RollSpare(4, 6);
			        	});
			game.RollStrike();
			game.RollTenthFrame(4, 6, 10);
		}

		[Specification]
		public void score_is_200()
		{
			game.Score.should_equal(200);
		}
	}
}