namespace BabylonScore.Models;

public class Standing
{
    public int Rank { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string TeamFlag { get; set; } = string.Empty;
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public int Points { get; set; }
    public string Form { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
}
