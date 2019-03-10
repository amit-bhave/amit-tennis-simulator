using System;


namespace Tennis.Simulator.Models
{
	/// <summary>
	/// Model Class for Set in Match.
	/// </summary>
	public class Set
	{
		public SetState SetState { get; set; }
		public int PlayerOneGames { get; set; }
		public int PlayerTwoGames { get; set; }

		public Set()
		{
			SetState = SetState.InProgress;
			PlayerOneGames = 0;
			PlayerTwoGames = 0;
		}

		/// <summary>
		/// Event Handler to process game won event in Set
		/// </summary>
		/// <param name="winner">Player Winning Game</param>
		public void WinGame(PlayerSide winner)
		{
			if (winner == PlayerSide.SideOne)
			{
				PlayerOneGames++;
			}

			if (winner == PlayerSide.SideTwo)
			{
				PlayerTwoGames++;
			}

			if ((PlayerOneGames >= 6 || PlayerTwoGames >= 6) && Math.Abs(PlayerOneGames - PlayerTwoGames) >= 2)
			{
				SetState = PlayerOneGames > PlayerTwoGames ? SetState.WinBySideOne : SetState.WinBySideTwo;
			}
		}

		public string GetSetsCurrentScore()
		{
			return $"{PlayerOneGames} - {PlayerTwoGames}";
		}

		public void Reset()
		{
			SetState = SetState.InProgress;
			PlayerOneGames = 0;
			PlayerTwoGames = 0;
		}
	}
}
