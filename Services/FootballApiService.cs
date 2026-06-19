using System.Net.Http.Json;
using BabylonScore.Models;

namespace BabylonScore.Services;

public class FootballApiService
{
    private readonly HttpClient _http;

    // Free API: football-data.org (free tier: 10 req/min)
    // Sign up at https://www.football-data.org/client/register
    private const string BaseUrl = "https://api.football-data.org/v4/";
    private const string ApiKey = "YOUR_API_KEY_HERE";

    public FootballApiService()
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl),
            DefaultRequestHeaders = { { "X-Auth-Token", ApiKey } }
        };
    }

    public async Task<List<Match>> GetLiveMatchesAsync()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse>("matches");
            return response?.Matches?.Select(MapToMatch).ToList() ?? [];
        }
        catch
        {
            return [];
        }
    }

    public async Task<List<Team>> GetTeamsAsync(int competitionId = 2000)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<TeamResponse>($"competitions/{competitionId}/teams");
            return response?.Teams?.Select(t => new Team
            {
                Name = t.Name,
                Flag = t.CrestUrl ?? string.Empty,
                WorldRanking = 0
            }).ToList() ?? [];
        }
        catch
        {
            return [];
        }
    }

    public async Task<List<Standing>> GetStandingsAsync(int competitionId = 2000)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<StandingResponse>($"competitions/{competitionId}/standings");
            var standings = new List<Standing>();
            if (response?.Standings == null) return standings;

            foreach (var table in response.Standings)
            {
                if (table.Table == null) continue;
                standings.AddRange(table.Table.Select((row, idx) => new Standing
                {
                    Rank = idx + 1,
                    TeamName = row.Team?.Name ?? "",
                    TeamFlag = row.Team?.CrestUrl ?? "",
                    Played = row.PlayedGames,
                    Won = row.Won,
                    Drawn = row.Draw,
                    Lost = row.Lost,
                    GoalsFor = row.GoalsFor,
                    GoalsAgainst = row.GoalsAgainst,
                    Points = row.Points,
                    GroupName = table.Group ?? "League"
                }));
            }
            return standings;
        }
        catch
        {
            return [];
        }
    }

    private static Match MapToMatch(ApiMatch m)
    {
        return new Match
        {
            Id = m.Id,
            HomeTeam = m.HomeTeam?.Name ?? "",
            AwayTeam = m.AwayTeam?.Name ?? "",
            HomeFlag = m.HomeTeam?.CrestUrl ?? "",
            AwayFlag = m.AwayTeam?.CrestUrl ?? "",
            HomeScore = m.Score?.FullTime?.Home,
            AwayScore = m.Score?.FullTime?.Away,
            Status = m.Status ?? "Scheduled",
            Minute = m.Status == "IN_PLAY" ? "Live" : m.Status ?? "",
            Venue = m.Venue ?? "",
            Round = m.Matchday > 0 ? $"Matchday {m.Matchday}" : ""
        };
    }

    // API Response DTOs
    private record ApiResponse(List<ApiMatch>? Matches);
    private record ApiMatch(int Id, string? Status, int Matchday, string? Venue,
        ApiTeam? HomeTeam, ApiTeam? AwayTeam, ApiScore? Score);
    private record ApiTeam(string Name, string? CrestUrl);
    private record ApiScore(ApiScoreDetail? FullTime, ApiScoreDetail? HalfTime);
    private record ApiScoreDetail(int? Home, int? Away);

    private record TeamResponse(List<ApiTeamEntry>? Teams);
    private record ApiTeamEntry(string Name, string? CrestUrl);

    private record StandingResponse(List<StandingTable>? Standings);
    private record StandingTable(string? Group, List<StandingRow>? Table);
    private record StandingRow(int Position, int PlayedGames, int Won, int Draw, int Lost,
        int GoalsFor, int GoalsAgainst, int Points, ApiTeamEntry? Team);
}
