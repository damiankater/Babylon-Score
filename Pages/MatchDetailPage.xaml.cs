using BabylonScore.Models;

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
    }

    private void LoadMatch(int id)
    {
        var allMatches = MockDataStore.GetLiveMatches()
            .Concat(MockDataStore.GetUpcomingMatches())
            .Concat(MockDataStore.GetRecentResults());

        var match = allMatches.FirstOrDefault(m => m.Id == id);
        if (match == null) return;

        HomeTeamLabel.Text = match.HomeTeam;
        AwayTeamLabel.Text = match.AwayTeam;
        ScoreLabel.Text = match.ScoreDisplay;
        StatusLabel.Text = match.Minute;
        RoundLabel.Text = match.Round;
        VenueLabel.Text = $"{match.Venue} • {match.Date}";
        H2HHomeLabel.Text = match.HomeTeam;
        H2HAwayLabel.Text = match.AwayTeam;

        var stats = new List<MatchStat>
        {
            new() { Label = "Possession", HomeValue = match.HomePossession, AwayValue = match.AwayPossession },
            new() { Label = "Total Shots", HomeValue = match.HomeShots, AwayValue = match.AwayShots },
            new() { Label = "Shots on Target", HomeValue = match.HomeShotsOnTarget, AwayValue = match.AwayShotsOnTarget },
            new() { Label = "Corners", HomeValue = match.HomeCorners, AwayValue = match.AwayCorners }
        };

        foreach (var stat in stats)
        {
            StatsContainer.Children.Add(CreateStatBar(stat));
        }
    }

    private View CreateStatBar(MatchStat stat)
    {
        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(80),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(36),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(80)
            },
            RowDefinitions = { new RowDefinition(GridLength.Auto), new RowDefinition(GridLength.Auto) },
            RowSpacing = 4,
            ColumnSpacing = 8
        };

        var label = new Label { Text = stat.Label, FontSize = 10, TextColor = (Color)Application.Current!.Resources["OnSurfaceVariant"] };
        Grid.SetColumn(label, 0);
        Grid.SetRowSpan(label, 2);
        grid.Children.Add(label);

        var homeVal = new Label { Text = stat.HomeValue.ToString(), FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = (Color)Application.Current!.Resources["OnSurface"], HorizontalTextAlignment = TextAlignment.End };
        Grid.SetColumn(homeVal, 1);
        Grid.SetRow(homeVal, 0);
        grid.Children.Add(homeVal);

        var awayVal = new Label { Text = stat.AwayValue.ToString(), FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = (Color)Application.Current!.Resources["OnSurface"] };
        Grid.SetColumn(awayVal, 3);
        Grid.SetRow(awayVal, 0);
        grid.Children.Add(awayVal);

        var homeBar = new BoxView { CornerRadius = 2, HeightRequest = 4, Color = (Color)Application.Current!.Resources["Gold"], HorizontalOptions = LayoutOptions.End };
        homeBar.WidthRequest = Math.Max(stat.HomePercent * 2, 4);
        Grid.SetColumn(homeBar, 1);
        Grid.SetRow(homeBar, 1);
        grid.Children.Add(homeBar);

        var labelPct = new Label { Text = $"{stat.HomePercent}%", FontSize = 9, TextColor = (Color)Application.Current!.Resources["Gold"], HorizontalTextAlignment = TextAlignment.Center };
        Grid.SetColumn(labelPct, 2);
        Grid.SetRow(labelPct, 1);
        grid.Children.Add(labelPct);

        var awayBar = new BoxView { CornerRadius = 2, HeightRequest = 4, Color = (Color)Application.Current!.Resources["TerraCotta"], HorizontalOptions = LayoutOptions.Start };
        awayBar.WidthRequest = Math.Max(stat.AwayPercent * 2, 4);
        Grid.SetColumn(awayBar, 3);
        Grid.SetRow(awayBar, 1);
        grid.Children.Add(awayBar);

        return grid;
    }
}
