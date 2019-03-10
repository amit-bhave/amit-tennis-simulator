using System.Collections.Generic;

namespace Tennis.Simulator.Services.Status
{
	public class SetStatus
	{
		public string Score { get; set; }
		public List<GameStatus> GameScores { get; set; }
	}
}
