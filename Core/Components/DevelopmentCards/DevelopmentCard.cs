using Core.Components.Tokens;

namespace Core.Components.DevelopmentCards;
public record DevelopmentCard(int Points, TokenType BonusToken, Dictionary<TokenType, int> Cost);