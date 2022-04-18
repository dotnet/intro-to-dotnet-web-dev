using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestConnectFour.GameState;

public class WinningPlaces
{

	public WinningPlaces(ITestOutputHelper logger)
	{
		Logger = logger;
	}

	public ITestOutputHelper Logger { get; }

	[Fact]
	public void Calculate()
	{

		foreach (var item in ConnectFour.Shared.GameState.WinningPlaces)
		{
			Logger.WriteLine(String.Join(',', item));
		}

		Logger.WriteLine(ConnectFour.Shared.GameState.WinningPlaces.Count.ToString());

	}

}

