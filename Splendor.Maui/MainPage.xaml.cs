using Core;
using Core.Components.DevelopmentCards;
using Core.Components.Nobels;
using Core.Components.Tokens;
using Splendor.Maui.Components;

namespace Splendor.Maui;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        //BindingContext = viewModel;
        var card = viewModel._factory?.CreateCards()[DevelopmentCardlevel.Third].First();
        DevCardView.Card = card;

        //// Example of adding gem tokens
        //var blueToken = new TokenView { TokenText = "Blue" };

        //// Add tokens to the board (assuming you have a layout to place them)
        //GameBoard.Children.Add(blueToken);
    }
}

