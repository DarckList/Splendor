namespace Core.Components.DevelopmentCards;
public interface IDevelopmentCardFactory
{
    public Dictionary<DevelopmentCardlevel, Stack<DevelopmentCard>> CreateCards();
}
