using System.Collections.Generic;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.Status;

namespace Tennis.Simulator.Services.InterFaces
{
	public interface ISetService
	{
		List<GameStatus> GameScores { get; set; }
		PlayerSide Play();
	}
}
