namespace Core.Components.DevelopmentCards;

public enum DevelopmentCardlevel
{
    First = 1,
    Second,
    Third
}

public static class DevelopmentCardlevelExtension
{

    public static int GetDevelopmentCardlevelCount(this DevelopmentCardlevel cardLevel) => cardLevel switch
    {
        DevelopmentCardlevel.First => 40,
        DevelopmentCardlevel.Second => 30,
        DevelopmentCardlevel.Third => 20,
        _ => throw cardLevel.CardLevelException()
    };

    public static ArgumentOutOfRangeException CardLevelException(this DevelopmentCardlevel cardLevel)
    {
        return new ArgumentOutOfRangeException(nameof(cardLevel), $"Not expected Development Card level: {cardLevel}");
    }
}
