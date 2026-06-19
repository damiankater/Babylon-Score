using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class WorldCupHubPage : ContentPage
{
    public WorldCupHubPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Load standings from DatabaseService
        StandingsCollection.ItemsSource = DatabaseService.Instance.Standings;
    }

    private async void OnBackClicked(object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
