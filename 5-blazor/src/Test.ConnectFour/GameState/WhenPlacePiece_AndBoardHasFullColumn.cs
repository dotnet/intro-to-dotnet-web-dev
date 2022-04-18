using System;
using Xunit;

namespace TestConnectFour.GameState;

public class WhenPlacePiece_AndBoardHasFullColumn
{

	private ConnectFour.Shared.GameState sut = new();

	public WhenPlacePiece_AndBoardHasFullColumn()
	{

		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);
		sut.PlayPiece(0);

	}

	[Fact]
	public void ShouldEndInSecondFromBottomRow()
	{

		Assert.Throws<ArgumentException>(() => sut.PlayPiece(0));
	}

}

