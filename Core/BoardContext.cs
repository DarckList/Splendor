using Core.Components;
using Core.Components.Nobels;

namespace Core;
internal class BoardContext
{
	public List<Player> Players { get; init; } = new();
	public List<Nobel> Nobels { get; init; } = new();
	public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> DevelopmentCards { get; init; } = new();
	public bool IsEnd { get; set; } = false;
}
