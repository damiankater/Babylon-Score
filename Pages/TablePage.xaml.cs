using BabylonScore.Models;

namespace BabylonScore.Pages;

public partial class TablePage : ContentPage
{
    public TablePage()
    {
        InitializeComponent();
        LoadStandings();
    }

    private void LoadStandings()
    {
        var all = MockDataStore.GetAllGroupStandings();
        var grouped = all.GroupBy(s => s.GroupName)
                         .Select(g => new TableGrouping(g.Key, g.ToList()))
                         .ToList();
        StandingsList.ItemsSource = grouped;
    }
}

public class TableGrouping : List<Standing>
{
    public string Key { get; }
    public TableGrouping(string key, List<Standing> items) : base(items) => Key = key;
}
