using Core.Components.DevelopmentCards;
using Core.Components.Nobels;
using Core.Components.Tokens;

namespace Core.Components.Players;

public class Player
{
	private readonly string _nickName;

	public Dictionary<TokenType, int> Tokens { get; init; } = new();
	public List<DevelopmentCard> Cards { get; init; } = new();
	public List<Nobel> Nobles { get; init; } = new();
	public int Points { get; private set; } = 0;


	public Player(string nickName)
	{
		_nickName = nickName;
	}

	public void AddToken(Token token)
	{
		ArgumentNullException.ThrowIfNull(token);
		Tokens[token.Type] += token.Count;
	}

	public void AddDevelopmentCard(DevelopmentCard card)
	{
		ArgumentNullException.ThrowIfNull(card);
		if (CanAddDevelopmentCard(card))
		{
			Cards.Add(card);
			Points += card.Points;
		}
	}

	public void AddNoble(Nobel noble)
	{
		ArgumentNullException.ThrowIfNull(noble);
		if (CanAddNobel(noble))
		{
			Nobles.Add(noble);
			Points += noble.Points;
		}
	}

	public void ApplyGoldenToken(TokenType swapTokenType)
	{
		if (Tokens.Any(t => t.Key == TokenType.Gold && t.Value >= 1 ))
		{
			Tokens[TokenType.Gold]--;
			Token newToken = new(swapTokenType, 1);
			AddToken(newToken);
		}
	}

	public bool CanAddNobel(Nobel nobel)
	{
		ArgumentNullException.ThrowIfNull(nobel);
		var cardBonuses = Cards.GroupBy(c => c.BonusToken).ToDictionary(cg => cg.Key, cg => cg.Count());
		return nobel.Cost.All(nobelCost => cardBonuses[nobelCost.Key] >= nobelCost.Value);
	}

	public bool CanAddDevelopmentCard(DevelopmentCard developmentCard)
	{
		ArgumentNullException.ThrowIfNull(developmentCard);
		var allTokens = GetAllTokens();
		return developmentCard.Cost.All(cardCost => allTokens[cardCost.Key] > cardCost.Value);
	}

	public Dictionary<TokenType, int> GetAllTokens()
	{
		Dictionary<TokenType, int> currentTokens = new(Tokens);
		foreach (var card in Cards)
		{
			if (!currentTokens.ContainsKey(card.BonusToken))
			{
				currentTokens.Add(card.BonusToken, 0);
			}
			currentTokens[card.BonusToken]++;
		}
		return currentTokens;
	}
}
