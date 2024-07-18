namespace Core.Components.Tokens;
public class Token
{

	public TokenType Type { get; private set; }
	public int Count { get; private set; }

	public Token(TokenType type, int ammount)
	{
		Type = type;
		Count = ammount;
	}

	public void SpendTokens(int price)
	{
		Count -= price;

	}

	public void IncreaseTokens(int ammount)
	{
		if (ammount <= 0)
		{
			Console.WriteLine("ammount shoud be positiv value");
			return;
		}
		Count += ammount;
	}
}
