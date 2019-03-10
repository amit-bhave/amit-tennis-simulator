namespace Tennis.Simulator.Models
{
	/// <summary>
	/// Model Class for Game in a Match.
	/// </summary>
	public class Game
	{
		public GameState GameState { get; set; }
		public Points PlayerOnePoints { get; set; }
		public Points PlayerTwoPoints { get; set; }

		public Game()
		{
			GameState = GameState.InProgress;
			PlayerOnePoints = Points.Love;
			PlayerTwoPoints = Points.Love;
		}

		private Points GetPoints(PlayerSide side)
		{
			return side == PlayerSide.SideOne ? PlayerOnePoints : PlayerTwoPoints;
		}

		private void SetPoints(PlayerSide side, Points point)
		{
			if (side == PlayerSide.SideOne)
			{
				PlayerOnePoints = point;
			}

			else
			{
				PlayerTwoPoints = point;
			}
		}

		private bool IsStillBeingPlayed()
		{
			return GameState == GameState.InProgress || GameState == GameState.Deuce;

		}

		private bool IsDeuce()
		{
			return PlayerOnePoints == Points.Deuce && PlayerTwoPoints == Points.Deuce;
		}

		private void AddPointtoSide(PlayerSide winner)
		{
			var points = GetPoints(winner);			

			switch (points)
			{
				case Points.None:
					SetPoints(winner, Points.Love);
					break;
				case Points.Love:
					SetPoints(winner, Points.Fifteen);
					break;
				case Points.Fifteen:
					SetPoints(winner, Points.Thirty);
					break;
				case Points.Thirty:
					var opponentPoints = winner == PlayerSide.SideOne ? PlayerTwoPoints : PlayerOnePoints;
					if (opponentPoints == Points.Forty)
					{
						PlayerOnePoints = Points.Deuce;
						PlayerTwoPoints = Points.Deuce;
					}
					else
					{
						SetPoints(winner, Points.Forty);
					}					
					break;
				case Points.Forty:
					SetPoints(winner, Points.Win);
					break;
				case Points.Deuce:
					var opponentPointsDeuce = winner == PlayerSide.SideOne ? PlayerTwoPoints : PlayerOnePoints;
					if (opponentPointsDeuce == Points.Advantage)
					{
						PlayerOnePoints = Points.Deuce;
						PlayerTwoPoints = Points.Deuce;
					}
					else
					{
						SetPoints(winner, Points.Advantage);
					}					
					break;
				case Points.Advantage:
					SetPoints(winner, Points.Win);
					break;
			}
		}

		private GameState FinishGameandReturnWinner(PlayerSide winningSide)
		{
			return winningSide == PlayerSide.SideOne ? GameState.WonByPlayerOne : GameState.WonByPlayerTwo;
		}

		private string GetScoreFromPoint(Points point)
		{
			switch (point)
			{
				case Points.Love:
					return "love";
				case Points.Fifteen:
					return "fifteen";
				case Points.Thirty:
					return "thirty";
				case Points.Forty:
					return "forty";
				default:
					return string.Empty;
			}
		}

		/// <summary>
		/// Event Handler to process winning point.
		/// </summary>
		/// <param name="pointWinnerSide">Side winning point.</param>
		public void WinPoint(PlayerSide pointWinnerSide)
		{
			if (IsStillBeingPlayed())
			{
				AddPointtoSide(pointWinnerSide);

				if (IsDeuce())
				{
					GameState = GameState.Deuce;
				}

				if (GetPoints(pointWinnerSide) == Points.Win)
				{
					GameState = FinishGameandReturnWinner(pointWinnerSide);
				}
			}
		}

		public string ReturnGamesCurrentScore()
		{
			if (GameState == GameState.WonByPlayerOne)
			{
				return "Game  - Side One";
			}

			if (GameState == GameState.WonByPlayerTwo)
			{
				return "Game - Side Two";
			}

			if (PlayerOnePoints == Points.Advantage)
			{
				return "Advantage - Side One";
			}

			if (PlayerTwoPoints == Points.Advantage)
			{
				return "Advantage - Side Two";
			}

			if (PlayerOnePoints == Points.Deuce && PlayerTwoPoints == Points.Deuce)
			{
				return "Deuce";
			}

			var sideone = GetScoreFromPoint(PlayerOnePoints);
			var sidetwo = GetScoreFromPoint(PlayerTwoPoints);

			return $"{sideone} - {sidetwo}";
		}

		public void Reset()
		{
			GameState = GameState.InProgress;
			PlayerOnePoints = Points.Love;
			PlayerTwoPoints = Points.Love;
		}
	}
}
