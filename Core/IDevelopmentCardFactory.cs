using Core.Components;

namespace Core;
public interface IDevelopmentCardFactory
{
	public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> CreateCards();
}
