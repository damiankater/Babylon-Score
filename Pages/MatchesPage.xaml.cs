using BabylonScore.Models;

namespace BabylonScore.Pages;

public partial class MatchesPage : ContentPage
{
    public MatchesPage()
    {
        InitializeComponent();
        LoadMatches();
    }

    private void LoadMatches()
    {
        var grouped = new List<Grouping>();
        grouped.Add(new Grouping("LIVE", MockDataStore.GetLiveMatches().ToList()));
        grouped.Add(new Grouping("UPCOMING", MockDataStore.GetUpcomingMatches().ToList()));
        grouped.Add(new Grouping("RESULTS", MockDataStore.GetRecentResults().ToList()));
        AllMatchesList.ItemsSource = grouped;
    }

    private void OnFilterClicked(object? sender, EventArgs e)
    {
        if (sender is not Button btn) return;
        if (btn.Parent is not HorizontalStackLayout parent) return;
        foreach (var child in parent.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = (Color)Application.Current!.Resources["SurfaceVariant"];
                b.TextColor = (Color)Application.Current!.Resources["OnSurface"];
            }
        }
        btn.BackgroundColor = (Color)Application.Current!.Resources["Gold"];
        btn.TextColor = (Color)Application.Current!.Resources["OnPrimary"];
    }

    private async void OnMatchSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Match match)
        {
            await Shell.Current.GoToAsync($"{nameof(MatchDetailPage)}?matchId={match.Id}");
            if (sender is CollectionView cv) cv.SelectedItem = null;
        }
    }
}

public class Grouping : List<Match>
{
    public string Key { get; }
    public Grouping(string key, List<Match> items) : base(items) => Key = key;
}
