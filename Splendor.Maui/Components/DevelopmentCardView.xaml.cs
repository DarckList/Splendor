namespace Splendor.Maui.Components;
using Core.Components.DevelopmentCards;

public partial class DevelopmentCardView : ContentView
{
    public DevelopmentCardView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty CardProperty =
        BindableProperty.Create(nameof(Card), typeof(DevelopmentCard), typeof(DevelopmentCardView), null, propertyChanged: OnCardChanged);

    public DevelopmentCard Card
    {
        get => (DevelopmentCard)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }

    private static void OnCardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (DevelopmentCardView)bindable;
        if (newValue is DevelopmentCard card)
        {
            control.CardPoints.Text = $"Points: {card.Points}";
            control.CardBonusToken.Text = $"Bonus: {card.BonusToken}";
            control.CardCost.Children.Clear();

            foreach (var cost in card.Cost)
            {
                control.CardCost.Children.Add(new Label { Text = $"{cost.Key}: {cost.Value}" });
            }
        }
    }
}