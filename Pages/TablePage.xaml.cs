using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class TablePage : ContentPage
{
    public TablePage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
        LocalizationManager.Instance.LanguageChanged += (s, e) => LoadStandings();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadStandings();
    }

    private void LoadStandings()
    {
        var isAr = LocalizationManager.Instance.IsArabic;
        var list = DatabaseService.Instance.Standings.Select(s => new Standing
        {
            Rank = s.Rank,
            TeamName = isAr ? TranslateTeam(s.TeamName) : s.TeamName,
            TeamFlag = s.TeamFlag,
            Played = s.Played,
            Won = s.Won,
            Drawn = s.Drawn,
            Lost = s.Lost,
            GoalsFor = s.GoalsFor,
            GoalsAgainst = s.GoalsAgainst,
            Points = s.Points,
            Form = s.Form,
            GroupName = s.GroupName
        }).ToList();

        StandingsList.ItemsSource = list;
    }

    private string TranslateTeam(string englishName)
    {
        return englishName switch
        {
            "Iraq" => "العراق",
            "Argentina" => "الأرجنتين",
            "Netherlands" => "هولندا",
            "Senegal" => "السنغال",
            _ => englishName
        };
    }
}
