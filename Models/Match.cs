namespace BabylonScore.Models;

public class Match
{
    public int Id { get; set; }
    public string HomeTeam { get; set; } = string.Empty;
    public string AwayTeam { get; set; } = string.Empty;
    public string HomeFlag { get; set; } = string.Empty;
    public string AwayFlag { get; set; } = string.Empty;
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public string ScoreDisplay => HomeScore.HasValue ? $"{HomeScore} - {AwayScore}" : "vs";
    public string Minute { get; set; } = "0'";
    public string Status { get; set; } = "Scheduled";
    public bool IsLive => Status == "Live";
    public string Venue { get; set; } = string.Empty;
    public string Round { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public int HomePossession { get; set; }
    public int AwayPossession { get; set; }
    public int HomeShots { get; set; }
    public int AwayShots { get; set; }
    public int HomeShotsOnTarget { get; set; }
    public int AwayShotsOnTarget { get; set; }
    public int HomeCorners { get; set; }
    public int AwayCorners { get; set; }
    public int HomeFouls { get; set; }
    public int AwayFouls { get; set; }
    public int HomeYellowCards { get; set; }
    public int AwayYellowCards { get; set; }
    public int HomeRedCards { get; set; }
    public int AwayRedCards { get; set; }
    public string GroupName { get; set; } = string.Empty;
}
