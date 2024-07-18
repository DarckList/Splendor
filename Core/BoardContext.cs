using Core.Components.DevelopmentCards;
using Core.Components.Nobels;
using Core.Components.Players;
using Core.Components.Tokens;

namespace Core;
internal class BoardContext
{
	public List<Token> Tokens { get; init; } = new();
	public List<Player> Players { get; init; } = new();
	public List<Nobel> Nobels { get; init; } = new();
	public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> DevelopmentCards { get; init; } = new();
	public bool IsEnd { get; set; } = false;
}
