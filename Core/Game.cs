using System.Text;
using Core.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public class Game
{
	private const int _minPlayers = 1;
	private const int _maxPlayers = 4;

	private readonly BoardContext _boardContext;

	public Game(IEnumerable<string> playerNames, IDevelopmentCardFactory developmentCardFactory)
	{
		_boardContext = new()
		{
			Players = InitPlayers(playerNames.ToList()),
			IsEnd = false,
			DevelopmentCards = developmentCardFactory.CreateCards(),
		};
	}
	
	private List<Player> InitPlayers(List<string> playerNames)
	{
		ArgumentNullException.ThrowIfNull(playerNames);
		ArgumentOutOfRangeException.ThrowIfGreaterThan(playerNames.Count, _maxPlayers);
		ArgumentOutOfRangeException.ThrowIfLessThan(playerNames.Count, _minPlayers);

		return playerNames.Select(name => new Player(name)).ToList();
	}

	public void Run()
	{
		while (!_boardContext.IsEnd)
		{
			Render();
			Console.WriteLine("Player {} move");
			Console.ReadLine();
			Console.Clear();
		}
	}


	private void Render()
	{
		Console.WriteLine("Players:");
		RenderPlayers();
	}

	private void RenderPlayers()
	{
		Helplers.RenderCollenction(_boardContext.Players, ConsoleColor.Green);
	}
}
