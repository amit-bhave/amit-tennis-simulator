namespace Tennis.Simulator.Models
{

	    public enum PlayerSide
	    {		    
		    SideOne,
		    SideTwo
	    }

	    public enum Points
	    {
		    None,
		    Love,
		    Fifteen,
		    Thirty,
		    Forty,
		    Deuce,
		    Advantage
	    }

	    public enum GameState
	    {		    
		    InProgress,
		    Deuce,
		    WonByPlayerOne,
		    WonByPlayerTwo
	    }

	    public enum SetState
	    {		    
		    InProgress,
		    WinBySideOne,
		    WinBySideTwo
	    }

	    public enum MatchState
	    {		    
		    InProgress,
		    WinByPlayerOne,
		    WinByPlayerTwo
	    }
	
}
