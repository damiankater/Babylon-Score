using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class MatchesPage : ContentPage
{
    private bool _filterLiveOnly = false;

    public MatchesPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
        LocalizationManager.Instance.LanguageChanged += (s, e) => LoadMatches();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadMatches();
    }

    private void LoadMatches()
    {
        var isAr = LocalizationManager.Instance.IsArabic;
        var rawMatches = DatabaseService.Instance.Matches;

        var mapped = rawMatches.Select(m => new Match
        {
            Id = m.Id,
            HomeTeam = isAr ? m.HomeTeamAr : m.HomeTeam,
            AwayTeam = isAr ? m.AwayTeamAr : m.AwayTeam,
            HomeFlag = m.HomeFlag,
            AwayFlag = m.AwayFlag,
            HomeScore = m.HomeScore,
            AwayScore = m.AwayScore,
            Minute = isAr ? m.MinuteAr : m.Minute,
            Status = isAr ? m.StatusAr : m.Status,
            Venue = isAr ? m.VenueAr : m.Venue,
            Round = isAr ? m.RoundAr : m.Round,
            LeagueName = isAr ? m.LeagueNameAr : m.LeagueName
        }).ToList();

        if (_filterLiveOnly)
        {
            AllMatchesList.ItemsSource = mapped.Where(m => m.Status == "Live" || m.Status == "مباشر").ToList();
        }
        else
        {
            AllMatchesList.ItemsSource = mapped;
        }
    }

    private void OnAllFilterClicked(object sender, EventArgs e)
    {
        _filterLiveOnly = false;
        AllFilterBtn.BackgroundColor = (Color)Application.Current!.Resources["Gold"];
        AllFilterBtn.TextColor = Colors.Black;
        LiveFilterBtn.BackgroundColor = (Color)Application.Current!.Resources["SurfaceVariant"];
        LiveFilterBtn.TextColor = (Color)Application.Current!.Resources["OnSurface"];
        LoadMatches();
    }

    private void OnLiveFilterClicked(object sender, EventArgs e)
    {
        _filterLiveOnly = true;
        LiveFilterBtn.BackgroundColor = (Color)Application.Current!.Resources["Gold"];
        LiveFilterBtn.TextColor = Colors.Black;
        AllFilterBtn.BackgroundColor = (Color)Application.Current!.Resources["SurfaceVariant"];
        AllFilterBtn.TextColor = (Color)Application.Current!.Resources["OnSurface"];
        LoadMatches();
    }

    private async void OnMatchSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Match selectedMatch)
        {
            AllMatchesList.SelectedItem = null;
            await Navigation.PushAsync(new MatchDetailPage(selectedMatch.Id));
        }
    }
}
