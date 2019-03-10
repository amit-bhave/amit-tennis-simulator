using Tennis.Simulator.Models;

namespace Tennis.Simulator.Services.InterFaces
{
	public interface IGetPointWinnerService
	{
		PlayerSide GeneratePointWinner();
	}
}
