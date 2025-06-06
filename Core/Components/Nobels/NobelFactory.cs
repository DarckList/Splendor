﻿using Core.Components.Tokens;

namespace Core.Components.Nobels;
internal class NobelFactory : INobelFactory
{
	private readonly Random _random;

	public NobelFactory(Random random)
	{
		_random = random;
	}

	public List<Nobel> CreateNobels(int playerCount)
	{
		List<Nobel> nobels = new();
		for (int i = 0; i < NobelsCountForPlayers(playerCount); i++)
		{
			nobels.Add(CreateNobel());
		}
		return nobels;
	}

	private int NobelsCountForPlayers(int playerCount) => playerCount switch
	{
		2 => 7,
		3 => 9,
		4 => 11,
		_ => throw new ArgumentOutOfRangeException(nameof(playerCount))
	};

	private Nobel CreateNobel()
	{
		return new Nobel(3, GenerateCost());
	}

	private Dictionary<TokenType, int> GenerateCost()
	{
		var notUsedTokenTypes = new Stack<TokenType>(GetRandomCardTokenTypes());
		var tokenCount = _random.Next(2, 3);
		if (tokenCount == 2)
		{
			return new Dictionary<TokenType, int>
			{
				{ notUsedTokenTypes.Pop(),4},
				{ notUsedTokenTypes.Pop(),4}
			};
		}
		else if (tokenCount == 3)
		{
			return new Dictionary<TokenType, int>
			{
				{ notUsedTokenTypes.Pop(),3},
				{ notUsedTokenTypes.Pop(),3},
				{ notUsedTokenTypes.Pop(),3}
			};
		}
		else throw new Exception($"Unnown Nobel card variant for {tokenCount} tokens");
	}

	private IEnumerable<TokenType> GetRandomCardTokenTypes()
	{
		var cardTokenTypes =  EnumHelper.GetCardTokenTypes();
		_random.Shuffle<TokenType>(cardTokenTypes.ToArray());
		return cardTokenTypes;
	}
}