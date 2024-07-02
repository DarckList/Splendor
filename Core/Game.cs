using Core.Components.DevelopmentCards;
using Core.Components.Nobels;
using Core.Components.Players;

namespace Core;

public class Game
{
	private const int _minPlayers = 1;
	private const int _maxPlayers = 4;

	private readonly BoardContext _boardContext;

	public Game(IEnumerable<string> playerNames, IDevelopmentCardFactory developmentCardFactory, INobelFactory nobelFactory)
	{
		var players = InitPlayers(playerNames);
		_boardContext = new()
		{
			Players = players,
			Nobels = nobelFactory.CreateNobels(players.Count),
			DevelopmentCards = developmentCardFactory.CreateCards(),
			IsEnd = false,
		};
	}

	private List<Player> InitPlayers(IEnumerable<string> playerNames)
	{
		ValidatePlayerNames(playerNames.ToList());
		return playerNames.Select(name => new Player(name)).ToList();
	}

	private void ValidatePlayerNames(List<string> playerNames)
	{
		ArgumentNullException.ThrowIfNull(playerNames);
		ArgumentOutOfRangeException.ThrowIfGreaterThan(playerNames.Count, _maxPlayers);
		ArgumentOutOfRangeException.ThrowIfLessThan(playerNames.Count, _minPlayers);
		//TODO what if a name will be a same???
	}

	public void Run()
	{
		while (!_boardContext.IsEnd)
		{
			
		}
	}
}
