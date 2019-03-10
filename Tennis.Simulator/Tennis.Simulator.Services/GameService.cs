using System.Collections.Generic;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services.InterFaces;

namespace Tennis.Simulator.Services
{
    public class GameService : IGameService
    {
	    private readonly IGetPointWinnerService _pointWinner;
	    private readonly Game _game;

	    public List<string> PointScores { get; set; }

	    public GameService(IGetPointWinnerService pointWinner, Game game)
	    {
		    _pointWinner = pointWinner;
		    _game = game;
	    }

	    public PlayerSide Play()
	    {
		    _game.Reset();

		    PointScores = new List<string>();

		    while (_game.GameState != GameState.WonByPlayerOne && _game.GameState != GameState.WonByPlayerTwo)
		    {
			    var pointwinner = _pointWinner.GeneratePointWinner();
			    _game.WinPoint(pointwinner);
			    PointScores.Add(_game.ReturnGamesCurrentScore());
		    }

		    return _game.GameState == GameState.WonByPlayerOne ? PlayerSide.SideOne : PlayerSide.SideTwo;
	    }
	}
}
