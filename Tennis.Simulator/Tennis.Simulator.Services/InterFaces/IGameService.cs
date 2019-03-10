using System.Collections.Generic;
using Tennis.Simulator.Models;

namespace Tennis.Simulator.Services.InterFaces
{
	public interface IGameService
	{
		List<string> PointScores { get; set; }
		PlayerSide Play();
	}
}
