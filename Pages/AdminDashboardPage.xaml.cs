using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class AdminDashboardPage : ContentPage
{
    private Match? _selectedMatch;

    public AdminDashboardPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadMatches();
    }

    private void LoadMatches()
    {
        MatchPicker.ItemsSource = DatabaseService.Instance.Matches.Select(m => $"{m.Id}: {m.HomeTeam} vs {m.AwayTeam}").ToList();
        EditorCard.IsVisible = false;
        _selectedMatch = null;
    }

    private void OnMatchSelected(object sender, EventArgs e)
    {
        if (MatchPicker.SelectedIndex < 0)
        {
            EditorCard.IsVisible = false;
            return;
        }

        var selectedStr = MatchPicker.ItemsSource[MatchPicker.SelectedIndex].ToString();
        var idStr = selectedStr?.Split(':')[0];
        if (int.TryParse(idStr, out int matchId))
        {
            _selectedMatch = DatabaseService.Instance.Matches.FirstOrDefault(m => m.Id == matchId);
            if (_selectedMatch != null)
            {
                TeamsHeaderLabel.Text = $"{_selectedMatch.HomeTeam} vs {_selectedMatch.AwayTeam}";
                StatusPicker.SelectedItem = _selectedMatch.Status;
                MinuteEntry.Text = _selectedMatch.Minute;
                HomeScoreEntry.Text = _selectedMatch.HomeScore?.ToString() ?? string.Empty;
                AwayScoreEntry.Text = _selectedMatch.AwayScore?.ToString() ?? string.Empty;

                HomePossEntry.Text = _selectedMatch.HomePossession.ToString();
                AwayPossEntry.Text = _selectedMatch.AwayPossession.ToString();
                HomeShotsEntry.Text = _selectedMatch.HomeShots.ToString();
                AwayShotsEntry.Text = _selectedMatch.AwayShots.ToString();
                HomeCornersEntry.Text = _selectedMatch.HomeCorners.ToString();
                AwayCornersEntry.Text = _selectedMatch.AwayCorners.ToString();

                EditorCard.IsVisible = true;
            }
        }
    }

    private async void OnSaveMatchClicked(object sender, EventArgs e)
    {
        if (_selectedMatch == null) return;

        _selectedMatch.Status = StatusPicker.SelectedItem?.ToString() ?? "Scheduled";
        _selectedMatch.StatusAr = _selectedMatch.Status switch
        {
            "Live" => "مباشر",
            "FT" => "انتهت",
            _ => "مجدولة"
        };

        _selectedMatch.Minute = MinuteEntry.Text ?? string.Empty;
        _selectedMatch.MinuteAr = _selectedMatch.Minute.Replace("Live", "مباشر");

        if (int.TryParse(HomeScoreEntry.Text, out int hs)) _selectedMatch.HomeScore = hs;
        else _selectedMatch.HomeScore = null;

        if (int.TryParse(AwayScoreEntry.Text, out int ascore)) _selectedMatch.AwayScore = ascore;
        else _selectedMatch.AwayScore = null;

        if (int.TryParse(HomePossEntry.Text, out int hp)) _selectedMatch.HomePossession = hp;
        if (int.TryParse(AwayPossEntry.Text, out int ap)) _selectedMatch.AwayPossession = ap;
        if (int.TryParse(HomeShotsEntry.Text, out int hsht)) _selectedMatch.HomeShots = hsht;
        if (int.TryParse(AwayShotsEntry.Text, out int asht)) _selectedMatch.AwayShots = asht;
        if (int.TryParse(HomeCornersEntry.Text, out int hc)) _selectedMatch.HomeCorners = hc;
        if (int.TryParse(AwayCornersEntry.Text, out int ac)) _selectedMatch.AwayCorners = ac;

        // Auto trigger events simulation for live update demo
        if (_selectedMatch.Status == "Live" && _selectedMatch.HomeScore > 0 && _selectedMatch.Events.Count == 0)
        {
            _selectedMatch.Events.Add(new MatchEvent { Minute = 10, Type = "Goal", PlayerName = "Admin Choice", Team = "Home", Detail = "Created by admin" });
        }

        DatabaseService.Instance.SaveData();
        await DisplayAlert("Success", "Match database updated & saved successfully!", "OK");
    }

    private async void OnPublishNewsClicked(object sender, EventArgs e)
    {
        var title = NewsTitleEntry.Text?.Trim();
        var titleAr = NewsTitleArEntry.Text?.Trim();
        var content = NewsContentEntry.Text?.Trim();
        var contentAr = NewsContentArEntry.Text?.Trim();

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
        {
            await DisplayAlert("Error", "Please fill English Title and Content at least.", "OK");
            return;
        }

        var newArticle = new NewsArticle
        {
            Id = DatabaseService.Instance.Articles.Count + 1,
            Title = title,
            TitleAr = string.IsNullOrEmpty(titleAr) ? title : titleAr,
            Summary = content.Length > 80 ? content.Substring(0, 80) + "..." : content,
            SummaryAr = string.IsNullOrEmpty(contentAr) ? (content.Length > 80 ? content.Substring(0, 80) : content) : (contentAr.Length > 80 ? contentAr.Substring(0, 80) + "..." : contentAr),
            Content = content,
            ContentAr = string.IsNullOrEmpty(contentAr) ? content : contentAr,
            Category = "Transfer",
            CategoryAr = "انتقالات",
            Timestamp = "Just now",
            TimestampAr = "الآن",
            ImageUrl = "iraq_flag.png"
        };

        DatabaseService.Instance.Articles.Insert(0, newArticle);
        DatabaseService.Instance.SaveData();

        NewsTitleEntry.Text = string.Empty;
        NewsTitleArEntry.Text = string.Empty;
        NewsContentEntry.Text = string.Empty;
        NewsContentArEntry.Text = string.Empty;

        await DisplayAlert("Success", "News article published!", "OK");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
