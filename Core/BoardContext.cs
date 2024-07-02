using Core.Components.DevelopmentCards;
using Core.Components.Nobels;
using Core.Components.Players;

namespace Core;
internal class BoardContext
{
	public List<Player> Players { get; init; } = new();
	public List<Nobel> Nobels { get; init; } = new();
	public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> DevelopmentCards { get; init; } = new();
	public bool IsEnd { get; set; } = false;
}
