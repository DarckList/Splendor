namespace Core.Components;
public record DevelopmentCard(int Points, TokenType BonusToken, Dictionary<TokenType, int> Cost);