using BabylonScore.Models;

namespace BabylonScore.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        LiveGamesList.ItemsSource = MockDataStore.GetLiveMatches();
        UpcomingList.ItemsSource = MockDataStore.GetUpcomingMatches();
        ResultsList.ItemsSource = MockDataStore.GetRecentResults();
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
