namespace Splendor.Maui.Components;

public partial class TokenView : ContentView
{
    public TokenView()
    {
        InitializeComponent();
    }

    public string TokenText
    {
        get => TokenLabel.Text;
        set => TokenLabel.Text = value;
    }
}