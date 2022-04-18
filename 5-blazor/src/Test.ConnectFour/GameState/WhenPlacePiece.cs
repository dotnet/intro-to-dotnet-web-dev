using System.Linq;
using Xunit;

namespace TestConnectFour.GameState;

public class WhenPlacePiece_AndBoardIsEmpty
{

	[Theory]
	[InlineData(0)]
	[InlineData(1)]
	[InlineData(2)]
	[InlineData(3)]
	[InlineData(4)]
	[InlineData(5)]
	[InlineData(6)]
	public void ShouldEndInBottomRow(byte column)
	{

		var sut = new ConnectFour.Shared.GameState();

		sut.PlayPiece(column);

		Assert.Equal(1, sut.TheBoard[42 - 7 + column]);

	}

	[Fact]
	public void ShouldBeOnlyPieceOnBoard()
	{

		var sut = new ConnectFour.Shared.GameState();

		sut.PlayPiece(0);

		Assert.Equal(1, sut.TheBoard.Count(t => t == 1));

	}

}

