namespace BabylonScore.Controls;

public partial class LuxuryMatchCard : ContentView
{
    public static readonly BindableProperty MatchProperty =
        BindableProperty.Create(nameof(Match), typeof(object), typeof(LuxuryMatchCard));

    public object Match
    {
        get => GetValue(MatchProperty);
        set => SetValue(MatchProperty, value);
    }

    public LuxuryMatchCard()
    {
        InitializeComponent();
    }
}
