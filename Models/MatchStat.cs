namespace BabylonScore.Models;

public class MatchStat
{
    public string Label { get; set; } = string.Empty;
    public int HomeValue { get; set; }
    public int AwayValue { get; set; }
    public int HomePercent => HomeValue + AwayValue > 0 ? (int)(HomeValue * 100.0 / (HomeValue + AwayValue)) : 50;
    public int AwayPercent => 100 - HomePercent;
}
