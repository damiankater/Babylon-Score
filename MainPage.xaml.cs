using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public ObservableCollection<LiveGame> LiveGames { get; set; }
    public ObservableCollection<ScheduledMatch> Schedule { get; set; }

    public MainPage()
    {
        InitializeComponent();
        
        LiveGames = new ObservableCollection<LiveGame>();
        Schedule = new ObservableCollection<ScheduledMatch>();
        
        LiveGamesList.ItemsSource = LiveGames;
        ScheduleList.ItemsSource = Schedule;
        
        LoadMockData();
    }

    private void LoadMockData()
    {
        // Live Games (mock data for demo)
        LiveGames.Add(new LiveGame { 
            Team1 = "Argentina 🇦🇷", 
            Team2 = "France 🇫🇷", 
            Team1Flag = "argentina.png",
            Score = "2 - 1",
            Status = "Live • 75'"
        });
        LiveGames.Add(new LiveGame { 
            Team1 = "Brazil 🇧🇷", 
            Team2 = "Germany 🇩🇪", 
            Team1Flag = "brazil.png",
            Score = "1 - 1",
            Status = "Live • 68'"
        });
        LiveGames.Add(new LiveGame { 
            Team1 = "USA 🇺🇸", 
            Team2 = "Mexico 🇲🇽", 
            Team1Flag = "usa.png",
            Score = "0 - 0",
            Status = "Live • 22'"
        });

        // Schedule (mock data)
        Schedule.Add(new ScheduledMatch { Match = "Spain vs Netherlands", Venue = "Arlington", Time = "18:00" });
        Schedule.Add(new ScheduledMatch { Match = "England vs Iran", Venue = "Atlanta", Time = "22:00" });
        Schedule.Add(new ScheduledMatch { Match = "Morocco vs Croatia", Venue = "Dallas", Time = "02:00" });
    }

    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        // Simulate refresh
        await DisplayAlert("Refreshed", "Live scores updated!", "OK");
    }
}

public class LiveGame
{
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public string Team1Flag { get; set; }
    public string Score { get; set; }
    public string Status { get; set; }
}

public class ScheduledMatch
{
    public string Match { get; set; }
    public string Venue { get; set; }
    public string Time { get; set; }
}