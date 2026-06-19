using BabylonScore.Pages;

namespace BabylonScore;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(MatchDetailPage), typeof(MatchDetailPage));
    }
}
