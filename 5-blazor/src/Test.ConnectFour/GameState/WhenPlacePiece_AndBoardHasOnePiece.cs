using System.Linq;
using Xunit;

namespace TestConnectFour.GameState;

public class WhenPlacePiece_AndBoardHasOnePiece
{

	private ConnectFour.Shared.GameState sut = new();

	public WhenPlacePiece_AndBoardHasOnePiece()
	{

		sut.PlayPiece(0);

	}

	[Theory]
	[InlineData(1)]
	[InlineData(2)]
	[InlineData(3)]
	[InlineData(4)]
	[InlineData(5)]
	[InlineData(6)]
	public void ShouldEndInBottomRow(byte column)
	{

		sut.PlayPiece(column);

		Assert.Equal(2, sut.TheBoard[42 - 7 + column]);

	}

	[Fact]
	public void ShouldBePlayerTwoTurn()
	{

		var landingPlace = sut.PlayPiece(1);

		Assert.Equal(2, sut.TheBoard[landingPlace]);

	}

	[Fact]
	public void ShouldBeTwoPiecesOnBoard()
	{

		sut.PlayPiece(0);

		Assert.Equal(2, sut.TheBoard.Count(t => t != 0));

	}

}

