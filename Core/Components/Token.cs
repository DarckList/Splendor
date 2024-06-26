using System.Drawing;

namespace Core.Components;
public class Token : IRendable
{
    
    public TokenType Type { get; private set; }
    public int Count { get; private set; }


    public ConsoleColor TokenColor { get; private set; }

    public Token(TokenType type, int ammount, ConsoleColor tokenColor)
    {
        Type = type;
		Count = ammount;
        TokenColor = tokenColor;
	}

    public void SpendTokens(int price)
    {
        Count -= price;

	}

    public void IncreaseTokens(int ammount)
    {
        if(ammount <=0)
        {
            Console.WriteLine("ammount shoud be positiv value");
            return;
        }
        Count += ammount;
    }

    public void Render()
    {
        var previewColor = Console.ForegroundColor;
        Console.ForegroundColor = TokenColor;
        Console.Write($"{RenderType()}-{Count}, ");
        Console.ForegroundColor = previewColor;
    }


	private string RenderType()
    {   
		return Type.ToString();
	}
}
