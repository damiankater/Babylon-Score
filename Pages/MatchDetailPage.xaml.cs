using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

[QueryProperty(nameof(MatchId), "matchId")]
public partial class MatchDetailPage : ContentPage
{
    private int _matchId;
    public int MatchId
    {
        get => _matchId;
        set
        {
            _matchId = value;
            LoadMatch(value);
        }
    }

    public MatchDetailPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
    }

    public MatchDetailPage(int matchId) : this()
    {
        _matchId = matchId;
        LoadMatch(matchId);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_matchId > 0)
        {
            LoadMatch(_matchId);
        }
    }

    private void LoadMatch(int id)
    {
        var match = DatabaseService.Instance.Matches.FirstOrDefault(m => m.Id == id);
        if (match == null) return;

        var isAr = LocalizationManager.Instance.IsArabic;

        HomeTeamLabel.Text = isAr ? match.HomeTeamAr : match.HomeTeam;
        AwayTeamLabel.Text = isAr ? match.AwayTeamAr : match.AwayTeam;
        HomeFlagImg.Source = match.HomeFlag;
        AwayFlagImg.Source = match.AwayFlag;
        ScoreLabel.Text = match.ScoreDisplay;
        StatusLabel.Text = isAr ? match.MinuteAr : match.Minute;
        RoundLabel.Text = isAr ? match.RoundAr : match.Round;
        VenueLabel.Text = $"{(isAr ? match.VenueAr : match.Venue)} • {(isAr ? match.DateAr : match.Date)}";

        // Refresh stats
        StatsContainer.Children.Clear();
        var stats = new List<MatchStat>
        {
            new() { Label = isAr ? "الاستحواذ" : "Possession", HomeValue = match.HomePossession, AwayValue = match.AwayPossession },
            new() { Label = isAr ? "التسديدات" : "Total Shots", HomeValue = match.HomeShots, AwayValue = match.AwayShots },
            new() { Label = isAr ? "التسديدات على المرمى" : "Shots on Target", HomeValue = match.HomeShotsOnTarget, AwayValue = match.AwayShotsOnTarget },
            new() { Label = isAr ? "الضربات الركنية" : "Corners", HomeValue = match.HomeCorners, AwayValue = match.AwayCorners },
            new() { Label = isAr ? "الأخطاء" : "Fouls", HomeValue = match.HomeFouls, AwayValue = match.AwayFouls },
            new() { Label = isAr ? "البطاقات الصفراء" : "Yellow Cards", HomeValue = match.HomeYellowCards, AwayValue = match.AwayYellowCards },
            new() { Label = isAr ? "البطاقات الحمراء" : "Red Cards", HomeValue = match.HomeRedCards, AwayValue = match.AwayRedCards }
        };

        foreach (var stat in stats)
        {
            StatsContainer.Children.Add(CreateStatBar(stat));
        }

        // Load timeline events
        EventsCollection.ItemsSource = match.Events;
    }

    private View CreateStatBar(MatchStat stat)
    {
        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(100),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(36),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(80)
            },
            RowDefinitions = { new RowDefinition(GridLength.Auto), new RowDefinition(GridLength.Auto) },
            RowSpacing = 4,
            ColumnSpacing = 8
        };

        var label = new Label { Text = stat.Label, FontSize = 11, TextColor = (Color)Application.Current!.Resources["OnSurfaceVariant"], VerticalTextAlignment = TextAlignment.Center };
        Grid.SetColumn(label, 0);
        Grid.SetRowSpan(label, 2);
        grid.Children.Add(label);

        var homeVal = new Label { Text = stat.HomeValue.ToString(), FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = (Color)Application.Current!.Resources["OnSurface"], HorizontalTextAlignment = TextAlignment.End };
        Grid.SetColumn(homeVal, 1);
        Grid.SetRow(homeVal, 0);
        grid.Children.Add(homeVal);

        var awayVal = new Label { Text = stat.AwayValue.ToString(), FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = (Color)Application.Current!.Resources["OnSurface"] };
        Grid.SetColumn(awayVal, 3);
        Grid.SetRow(awayVal, 0);
        grid.Children.Add(awayVal);

        var homeBar = new BoxView { CornerRadius = 2, HeightRequest = 4, Color = (Color)Application.Current!.Resources["Gold"], HorizontalOptions = LayoutOptions.End };
        homeBar.WidthRequest = Math.Max(stat.HomePercent * 1.5, 4);
        Grid.SetColumn(homeBar, 1);
        Grid.SetRow(homeBar, 1);
        grid.Children.Add(homeBar);

        var labelPct = new Label { Text = $"{stat.HomePercent}%", FontSize = 9, TextColor = (Color)Application.Current!.Resources["Gold"], HorizontalTextAlignment = TextAlignment.Center };
        Grid.SetColumn(labelPct, 2);
        Grid.SetRow(labelPct, 1);
        grid.Children.Add(labelPct);

        var awayBar = new BoxView { CornerRadius = 2, HeightRequest = 4, Color = (Color)Application.Current!.Resources["TerraCotta"], HorizontalOptions = LayoutOptions.Start };
        awayBar.WidthRequest = Math.Max(stat.AwayPercent * 1.5, 4);
        Grid.SetColumn(awayBar, 3);
        Grid.SetRow(awayBar, 1);
        grid.Children.Add(awayBar);

        return grid;
    }
}
