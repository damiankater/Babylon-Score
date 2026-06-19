namespace BabylonScore.Models;

public class NewsArticle
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string SummaryAr { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string ContentAr { get; set; } = string.Empty;
    public string Category { get; set; } = "General"; // "Transfer", "Match", "History"
    public string CategoryAr { get; set; } = "عام";
    public string Timestamp { get; set; } = string.Empty;
    public string TimestampAr { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
