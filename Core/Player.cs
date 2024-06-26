using System.Text;
using Core.Components;

namespace Core;

public class Player : IRendable
{
	private readonly string _nickName;

	public Dictionary<TokenType, Token> Tokens { get; init; }= new();
	public List<DevelopmentCard> Cards { get; init; } = new();

	public Player(string nickName)
	{
		_nickName = nickName;

		Tokens.Add(TokenType.Gold, new Token(TokenType.Gold, 2, ConsoleColor.Yellow));
		Tokens.Add(TokenType.Ruby, new Token(TokenType.Ruby, 2, ConsoleColor.Red));

	}

	//private Dictionary<TokenType, Token> GetCardsTokens()
	//{
	//	var b = Cards.ToDictionary(c => c.BonusToken);
	//	return b;
	//}

	public void Render()
	{
		Console.Write($@"{_nickName} have:
	Tokens:");
		RenderTokens();
		Console.WriteLine();
	}

	private void RenderTokens()
	{
		Helplers.RenderCollenction(Tokens.Values, ConsoleColor.Blue);		
	}
}
