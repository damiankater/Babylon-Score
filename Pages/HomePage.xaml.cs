using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
        LocalizationManager.Instance.LanguageChanged += OnLanguageChanged;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshLists();
        
        // Simulating live refreshes every time page appears
        // in production this would run a timer or websocket.
        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            // Trigger UI update
            MainThread.BeginInvokeOnMainThread(RefreshLists);
            return true; // Keep timer running
        });
    }

    private void OnLanguageChanged(object? sender, EventArgs e)
    {
        RefreshLists();
    }

    private void RefreshLists()
    {
        var isAr = LocalizationManager.Instance.IsArabic;

        // Map values if Arabic is selected
        var matches = DatabaseService.Instance.Matches.Select(m => new Match
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

        var articles = DatabaseService.Instance.Articles.Select(a => new NewsArticle
        {
            Id = a.Id,
            Title = isAr ? a.TitleAr : a.Title,
            Summary = isAr ? a.SummaryAr : a.Summary,
            Content = isAr ? a.ContentAr : a.Content,
            Category = isAr ? a.CategoryAr : a.Category,
            Timestamp = isAr ? a.TimestampAr : a.Timestamp
        }).ToList();

        LiveMatchesCollection.ItemsSource = matches.Where(m => m.Status == "Live" || m.Status == "مباشر").ToList();
        ArticlesCollection.ItemsSource = articles;
    }

    private async void OnMatchSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Match selectedMatch)
        {
            // Clear selection
            LiveMatchesCollection.SelectedItem = null;

            // Route to Detail Page
            var detailPage = new MatchDetailPage(selectedMatch.Id);
            await Navigation.PushAsync(detailPage);
        }
    }

    private async void OnWorldCupHubClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WorldCupHubPage());
    }

    private async void OnIraqStarsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Iraq Stars League", LocalizationManager.Instance.IsArabic ? "دوري نجوم العراق - مباشر" : "Iraq Stars League Hub - Live Updates Active!", "OK");
    }

    private async void OnUefaClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Champions League", LocalizationManager.Instance.IsArabic ? "دوري أبطال أوروبا - الجولة النهائية" : "UEFA Champions League Final Coverage!", "OK");
    }

    private async void OnAdminClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminLoginPage());
    }

    private void OnLanguageToggleClicked(object sender, EventArgs e)
    {
        LocalizationManager.Instance.CurrentLanguage = LocalizationManager.Instance.CurrentLanguage == "en" ? "ar" : "en";
    }
}
