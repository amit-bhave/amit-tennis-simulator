using System.Collections.Generic;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.Status;

namespace Tennis.Simulator.Services.InterFaces
{
	public interface IMatchService
	{
		List<SetStatus> SetScores { get; set; }
		PlayerSide Play();
	}
}
