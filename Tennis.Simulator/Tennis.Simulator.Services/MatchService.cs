using System.Collections.Generic;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.InterFaces;
using Tennis.Simulator.Services.Status;

namespace Tennis.Simulator.Services
{
	public class MatchService : IMatchService
	{
		private readonly ISetService _setService;
		private readonly Match _match;

		public List<SetStatus> SetScores { get; set; }

		public MatchService(ISetService setService, Match match)
		{
			_setService = setService;
			_match = match;
			SetScores = new List<SetStatus>();
		}

		public PlayerSide Play()
		{

			while (_match.MatchState != MatchState.WinByPlayerOne && _match.MatchState != MatchState.WinByPlayerTwo)
			{
				var setwinner = _setService.Play();

				_match.WinSet(setwinner);

				SetScores.Add(new SetStatus() { Score = _match.ShowMatchScore(), GameScores = _setService.GameScores });
			}

			return _match.MatchState == MatchState.WinByPlayerOne ? PlayerSide.SideOne : PlayerSide.SideTwo;
		}
	}
}
