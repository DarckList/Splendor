using Core.Components.DevelopmentCards;
using Core.Components.Tokens;

namespace Core.Components.Players;

public class Player
{
	private readonly string _nickName;

	public Dictionary<TokenType, Token> Tokens { get; init; } = new();
	public List<DevelopmentCard> Cards { get; init; } = new();

	public Player(string nickName)
	{
		_nickName = nickName;

	}
}
