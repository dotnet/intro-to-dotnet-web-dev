namespace ConnectFour;

public class GameState
{

	static GameState()
	{
		CalculateWinningPlaces();
	}

	/// <summary>
	/// Indicate whether a player has won, the game is a tie, or game in ongoing
	/// </summary>
	public enum WinState
	{
		No_Winner = 0,
		Player1_Wins = 1,
		Player2_Wins = 2,
		Tie = 3
	}

	/// <summary>
	/// The player whose turn it is.  By default, player 1 starts first
	/// </summary>
	public int PlayerTurn => TheBoard.Count(x => x != 0) % 2 + 1;

	/// <summary>
	/// Number of turns completed and pieces played so far in the game
	/// </summary>
	public int CurrentTurn { get { return TheBoard.Count(x => x != 0); } }

	public static readonly List<int[]> WinningPlaces = new();

	public static void CalculateWinningPlaces() 
	{

		// Horizontal rows
		for (byte row=0;row<6;row++){

			byte rowCol1 = (byte)(row * 7);
			byte rowColEnd = (byte)((row + 1) * 7 - 1);
			byte checkCol = rowCol1;
			while (checkCol <= rowColEnd-3)
			{
				WinningPlaces.Add(new int[] { 
					checkCol, 
					(byte)(checkCol + 1), 
					(byte)(checkCol + 2), 
					(byte)(checkCol + 3) 
					});
				checkCol++;
			}

		}

		// Vertical Columns
		for (byte col = 0; col < 7; col++)
		{

			byte colRow1 = col;
			byte colRowEnd = (byte)(35+col);
			byte checkRow = colRow1;
			while (checkRow <= 14+col)
			{
				WinningPlaces.Add(new int[] {
					checkRow,
					(byte)(checkRow + 7),
					(byte)(checkRow + 14),
					(byte)(checkRow + 21)
					});
				checkRow+=7;
			}

		}

		// forward slash diagonal "/"
		for (byte col = 0; col < 4; col++)
		{

			// starting column must be 0-3
			byte colRow1 = (byte)(21 + col);
			byte colRowEnd = (byte)(35 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				WinningPlaces.Add(new int[] {
					checkPos,
					(byte)(checkPos - 6),
					(byte)(checkPos - 12),
					(byte)(checkPos - 18)
					});
				checkPos += 7;
			}

		}

		// back slash diaganol "\"
		for (byte col = 0; col < 4; col++)
		{

			// starting column must be 0-3
			byte colRow1 = (byte)(0 + col);
			byte colRowEnd = (byte)(14 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				WinningPlaces.Add(new int[] {
					checkPos,
					(byte)(checkPos + 8),
					(byte)(checkPos + 16),
					(byte)(checkPos + 24)
					});
				checkPos += 7;
			}

		}


	}

	/// <summary>
	/// Check the state of the board for a winning scenario
	/// </summary>
	/// <returns>0 - no winner, 1 - player 1 wins, 2 - player 2 wins, 3 - draw</returns>
	public WinState CheckForWin()
	{

		// Exit immediately if less than 7 pieces are played
		if (TheBoard.Count(x => x != 0) < 7) return WinState.No_Winner;

		foreach (var scenario in WinningPlaces)
		{

			if (TheBoard[scenario[0]] == 0) continue;

			if (TheBoard[scenario[0]] ==
				TheBoard[scenario[1]] &&
				TheBoard[scenario[1]] ==
				TheBoard[scenario[2]] &&
				TheBoard[scenario[2]] ==
				TheBoard[scenario[3]]) return (WinState)TheBoard[scenario[0]];

		}

		if (TheBoard.Count(x => x != 0) == 42) return WinState.Tie;

		return WinState.No_Winner;

	}

	/// <summary>
	/// Takes the current turn and places a piece in the 0-indexed column requested
	/// </summary>
	/// <param name="column">0-indexed column to place the piece into</param>
	/// <returns>The final array index where the piece resides</returns>
	public byte PlayPiece(int column)
	{

		// Check for a current win
		if (CheckForWin() != 0) throw new ArgumentException("Game is over");

		// Check the column
		if (TheBoard[column] != 0) throw new ArgumentException("Column is full");

		// Drop the piece in
		var landingSpot = column;
		for (var i=column;i<42;i+=7)
		{
			if (TheBoard[landingSpot + 7] != 0) break;
			landingSpot = i;
		}

		TheBoard[landingSpot] = PlayerTurn;

		return ConvertLandingSpotToRow(landingSpot);

	}

	public List<int> TheBoard { get; private set; } = new List<int>(new int[42]);

	public void ResetBoard() {
		TheBoard = new List<int>(new int[42]);
	}

	private byte ConvertLandingSpotToRow(int landingSpot)
	{

		return (byte)(Math.Floor(landingSpot / (decimal)7) + 1);

	}

}