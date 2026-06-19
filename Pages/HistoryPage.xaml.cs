using BabylonScore.Models;

namespace BabylonScore.Pages;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
        TimelineList.ItemsSource = MockDataStore.GetTimeline();
    }
}
