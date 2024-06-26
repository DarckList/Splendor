namespace Core.Components;

public enum TokenType
{
	Diamond = 1,
	Sapphire,
	Emerald,
	Ruby,
	Onyx,
	Gold
}


public static class TokenTypeExtension
{
	public static ArgumentOutOfRangeException TokenTypeException(this TokenType tokenType)
	{
		return new ArgumentOutOfRangeException(nameof(tokenType), $"Not expected Token Type: {tokenType}");
	}
}