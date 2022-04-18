using Xunit;

namespace TestConnectFour.GameState;

public class WhenPlacePiece_AndBoardHasOnePieceInSameColumn
{

	private ConnectFour.Shared.GameState sut = new();

	public WhenPlacePiece_AndBoardHasOnePieceInSameColumn()
	{

		sut.PlayPiece(0);

	}

	[Fact]
	public void ShouldEndInSecondFromBottomRow()
	{

		sut.PlayPiece(0);

		Assert.Equal(1, sut.TheBoard[35]);
		Assert.Equal(2, sut.TheBoard[28]);

	}

}

public class WhenPlacePiece_AndBoardHasFivePiecesInSameColumn
{

	private ConnectFour.Shared.GameState sut = new();

	public WhenPlacePiece_AndBoardHasFivePiecesInSameColumn()
	{

		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);

	}

	[Fact]
	public void ShouldEndInSecondFromBottomRow()
	{

		sut.PlayPiece(0);

		Assert.Equal(1, sut.TheBoard[35]);
		Assert.Equal(2, sut.TheBoard[28]);
		Assert.Equal(1, sut.TheBoard[21]);
		Assert.Equal(2, sut.TheBoard[14]);
		Assert.Equal(1, sut.TheBoard[7]);
		Assert.Equal(2, sut.TheBoard[0]);

	}

}

