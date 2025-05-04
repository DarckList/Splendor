using Splendor.Maui;
using Core.Components.DevelopmentCards;

public class MainPageViewModel
{
    public IDevelopmentCardFactory _factory;

    public MainPageViewModel(IDevelopmentCardFactory factory)
    {
        _factory = factory;
    }
}