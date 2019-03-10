namespace Tennis.Simulator.Models
{
	/// <summary>
	/// Model Class for Match to be simulated.
	/// </summary>
	public class Match
	{
		public MatchState MatchState { get; set; }
		public int PlayerOneSetsWon { get; set; }
		public int PlayerTwoSetsWon { get; set; }

		public Match()
		{
			MatchState = MatchState.InProgress;
			PlayerOneSetsWon = 0;
			PlayerTwoSetsWon = 0;
		}

		public string ShowMatchScore()
		{
			return $"{PlayerOneSetsWon} - {PlayerTwoSetsWon}";
		}

		/// <summary>
		/// Event Handler to process event to win set in a match.
		/// </summary>
		/// <param name="winner">Side winning Set</param>
		public void WinSet(PlayerSide winner)
		{
			if (winner == PlayerSide.SideOne)
			{
				PlayerOneSetsWon++;
			}
			else
			{
				PlayerTwoSetsWon++;
			}

			if (PlayerOneSetsWon == 2)
			{
				MatchState = MatchState.WinByPlayerOne;
			}

			if (PlayerTwoSetsWon == 2)
			{
				MatchState = MatchState.WinByPlayerTwo;
			}
		}
	}
}
