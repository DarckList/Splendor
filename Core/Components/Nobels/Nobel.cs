using Core.Components.Tokens;

namespace Core.Components.Nobels;
public record Nobel(int Points, Dictionary<TokenType, int> Cost);
