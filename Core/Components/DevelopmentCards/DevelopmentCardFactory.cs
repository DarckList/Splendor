using Core.Components.Tokens;

namespace Core.Components.DevelopmentCards;
public class DevelopmentCardFactory : IDevelopmentCardFactory
{
    private readonly Random _random;
    private readonly Dictionary<DevelopmentCardlevel, List<DevelopmentCard>> _cards;

    private TokenType nextTokenType;

    public DevelopmentCardFactory(Random random)
    {
        _random = random;
        _cards = new();
        InitDevelopmentCards();
    }

    public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> CreateCards()
    {
        InitDevelopmentCards();
        ShakeCards();
        return ToDictionaryWithStack();
    }

    private Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> ToDictionaryWithStack()
    {
        var shuffledCards = new Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>>();

        foreach (var cardCollection in _cards)
        {
            shuffledCards[cardCollection.Key] = new Stack<DevelopmentCard>(cardCollection.Value);
        }

        return shuffledCards;
    }

    private void ShakeCards()
    {
        foreach (var cardCollection in _cards)
        {
            Shuffle(cardCollection.Value);
        }
    }

    private void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = _random.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    private void InitDevelopmentCards()
    {
        _cards.Clear();
        foreach (DevelopmentCardlevel cardLevel in Enum.GetValues(typeof(DevelopmentCardlevel)))
        {
            _cards.Add(cardLevel, new List<DevelopmentCard>());
            _cards.Add(cardLevel, new List<DevelopmentCard>());
            _cards.Add(cardLevel, new List<DevelopmentCard>());

            GenerateCards();
        }
    }

    private void GenerateCards()
    {
        FirstdLevelCardGenerator();
        SecondLevelCardGenerator();
        ThirdLevelCardGenerator();
    }

    private void FirstdLevelCardGenerator()
    {
        List<DevelopmentCard> developmentCards = new();
        Dictionary<TokenType, int> cost;
        foreach (TokenType bonusToken in GetCardTokenTypes())
        {
            int points = 1;
            // for one Token cost
            cost = new()
            {
                { GetNextTokenType(bonusToken), 4 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            points = 0;
            cost = new()
            {
                { GetNextTokenType(bonusToken), 3 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            // for two Token`s cost
            cost = new()
            {
                { GetNextTokenType(bonusToken), 2 },
                { GetNextTokenType(), 2 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            cost = new()
            {
                { GetNextTokenType(bonusToken), 1 },
                { GetNextTokenType(), 2 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            // for three Token`s cost
            cost = new()
            {
                { bonusToken, 1 },
                { GetNextTokenType(bonusToken), 1 },
                { GetNextTokenType(), 3 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
            cost = new()
            {
                { GetNextTokenType(bonusToken), 1 },
                { GetNextTokenType(), 2 },
                { GetNextTokenType(), 2 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            //for fore Token`s cost
            cost = new()
            {
                { GetNextTokenType(bonusToken), 1 },
                { GetNextTokenType(), 2 },
                { GetNextTokenType(), 1 },
                { GetNextTokenType(), 1 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
            cost = new()
            {
                { GetNextTokenType(bonusToken), 1 },
                { GetNextTokenType(), 1 },
                { GetNextTokenType(), 1 },
                { GetNextTokenType(), 1 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
        }
        _cards[DevelopmentCardlevel.First].AddRange(developmentCards);
    }

    private void SecondLevelCardGenerator()
    {
        List<DevelopmentCard> developmentCards = new();
        foreach (TokenType bonusToken in GetCardTokenTypes())
        {
            int points = 3;
            Dictionary<TokenType, int> cost = new()
        {
            { bonusToken, 6 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            points = 2;
            cost = new()
        {
            { bonusToken, 5 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            cost = new()
        {
            { GetNextTokenType(bonusToken), 5 },
            { GetNextTokenType(), 3 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            cost = new()
        {
            { GetNextTokenType(bonusToken), 1 },
            { GetNextTokenType(), 2 },
            { GetNextTokenType(), 4 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            points = 1;
            cost = new()
        {
            { bonusToken, 2 },
            { GetNextTokenType(bonusToken), 3 },
            { GetNextTokenType(), 2 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
            cost = new()
        {
            { bonusToken, 2 },
            { GetNextTokenType(bonusToken), 3 },
            { GetNextTokenType(), 3 }
        };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
        }


        _cards[DevelopmentCardlevel.Second].AddRange(developmentCards);
    }

    private void ThirdLevelCardGenerator()
    {
        List<DevelopmentCard> developmentCards = new();
        Dictionary<TokenType, int> cost;
        foreach (TokenType bonusToken in GetCardTokenTypes())
        {
            int points = 3;
            cost = new()
            {
                { GetNextTokenType(bonusToken), 5 },
                { GetNextTokenType(), 3 },
                { GetNextTokenType(), 3 },
                { GetNextTokenType(), 3 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));

            points = 4;
            cost = new()
            {
                { GetNextTokenType(bonusToken), 7 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));
            cost = new()
            {
                { bonusToken, 3 },
                { GetNextTokenType(bonusToken), 6 },
                { GetNextTokenType(), 3 }
            };
            developmentCards.Add(new DevelopmentCard(points, bonusToken, cost));


            points = 5;
            cost = new()
            {
                { bonusToken, 3 },
                { GetNextTokenType(bonusToken), 7 },
            };
        }
        _cards[DevelopmentCardlevel.Third].AddRange(developmentCards);
    }

    private TokenType GetNextTokenType()
    {
        nextTokenType++;
        if (nextTokenType == TokenType.Gold)
        {
            nextTokenType++;
        }
        if (!Enum.IsDefined(typeof(TokenType), nextTokenType))
        {
            nextTokenType = (TokenType)1;
        }

        return nextTokenType;
    }
    private TokenType GetNextTokenType(TokenType initTokenType)
    {
        nextTokenType = initTokenType;
        return GetNextTokenType();
    }


    private IEnumerable<TokenType> GetCardTokenTypes()
    {
        foreach (TokenType tokenType in Enum.GetValues<TokenType>())
        {
            if (tokenType == TokenType.Gold) continue;
            yield return tokenType;
        }
    }
}
