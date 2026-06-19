namespace BabylonScore.Models;

public class MatchEvent
{
    public int Minute { get; set; }
    public string Type { get; set; } = "Goal"; // "Goal", "YellowCard", "RedCard", "Substitution"
    public string PlayerName { get; set; } = string.Empty;
    public string Team { get; set; } = "Home"; // "Home" or "Away"
    public string Detail { get; set; } = string.Empty; // e.g. "Assist by Player X"
}
