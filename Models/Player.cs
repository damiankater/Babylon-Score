namespace BabylonScore.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Club { get; set; } = string.Empty;
    public int Age { get; set; }
    public int JerseyNumber { get; set; }
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int Appearances { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
}
