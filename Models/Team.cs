namespace BabylonScore.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public int Points { get; set; }
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public string Form { get; set; } = string.Empty;
    public int WorldRanking { get; set; }
}
