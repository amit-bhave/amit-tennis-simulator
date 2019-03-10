using System.Collections.Generic;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.InterFaces;
using Tennis.Simulator.Services.Status;

namespace Tennis.Simulator.Services
{
	public class SetService : ISetService
	{
		private readonly IGameService _gameService;
		private readonly Set _set;

		public List<GameStatus> GameScores { get; set; }

		public SetService(IGameService gameService, Set set)
		{
			_gameService = gameService;
			_set = set;
		}

		public PlayerSide Play()
		{
			_set.Reset();

			GameScores = new List<GameStatus>();

			while (_set.SetState != SetState.WinBySideOne && _set.SetState != SetState.WinBySideTwo)
			{
				var gamewinner = _gameService.Play();
				_set.WinGame(gamewinner);
				GameScores.Add(new GameStatus { Score = _set.GetSetsCurrentScore(), PointsScrore = _gameService.PointScores });
			}

			return _set.SetState == SetState.WinBySideOne ? PlayerSide.SideOne : PlayerSide.SideTwo;
		}
	}
}
