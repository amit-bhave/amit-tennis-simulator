using System;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.InterFaces;

namespace Tennis.Simulator.Services
{
	public class GetPointWinnerService : IGetPointWinnerService
	{
		private readonly Random _random;

		public GetPointWinnerService()
		{
			_random = new Random();
		}

		public PlayerSide GeneratePointWinner()
		{
			int randomNumber = _random.Next(1, 100);

			return randomNumber % 3 == 0 ? PlayerSide.SideTwo : PlayerSide.SideOne;
		}
	}
}

