using System.Collections.ObjectModel;

namespace BabylonScore.Models;

public static class MockDataStore
{
    public static ObservableCollection<Match> GetLiveMatches()
    {
        return new ObservableCollection<Match>
        {
            new()
            {
                Id = 1, HomeTeam = "Iraq", AwayTeam = "Argentina",
                HomeFlag = "iraq.png", AwayFlag = "argentina.png",
                HomeScore = 0, AwayScore = 0,
                Minute = "Live • 32'", Status = "Live",
                Venue = "Azadi Stadium, Tehran",
                HomePossession = 38, AwayPossession = 62,
                HomeShots = 3, AwayShots = 8,
                HomeShotsOnTarget = 1, AwayShotsOnTarget = 4,
                HomeCorners = 1, AwayCorners = 5
            },
            new()
            {
                Id = 2, HomeTeam = "Brazil", AwayTeam = "Germany",
                HomeFlag = "brazil.png", AwayFlag = "germany.png",
                HomeScore = 1, AwayScore = 1,
                Minute = "Live • 68'", Status = "Live",
                Venue = "Estadio Azteca, Mexico City",
                HomePossession = 55, AwayPossession = 45,
                HomeShots = 6, AwayShots = 4,
                HomeShotsOnTarget = 3, AwayShotsOnTarget = 2,
                HomeCorners = 4, AwayCorners = 2
            },
            new()
            {
                Id = 3, HomeTeam = "USA", AwayTeam = "Mexico",
                HomeFlag = "usa.png", AwayFlag = "mexico.png",
                HomeScore = 0, AwayScore = 0,
                Minute = "Live • 22'", Status = "Live",
                Venue = "SoFi Stadium, Los Angeles",
                HomePossession = 48, AwayPossession = 52,
                HomeShots = 2, AwayShots = 3,
                HomeShotsOnTarget = 1, AwayShotsOnTarget = 2,
                HomeCorners = 1, AwayCorners = 3
            }
        };
    }

    public static ObservableCollection<Match> GetUpcomingMatches()
    {
        return new ObservableCollection<Match>
        {
            new() { Id = 10, HomeTeam = "Spain", AwayTeam = "Netherlands", HomeFlag = "spain.png", AwayFlag = "netherlands.png", Time = "18:00", Venue = "AT&T Stadium, Arlington", Date = "Jun 20", Round = "Group A" },
            new() { Id = 11, HomeTeam = "England", AwayTeam = "Iran", HomeFlag = "england.png", AwayFlag = "iran.png", Time = "22:00", Venue = "Mercedes-Benz Stadium, Atlanta", Date = "Jun 20", Round = "Group B" },
            new() { Id = 12, HomeTeam = "Morocco", AwayTeam = "Croatia", HomeFlag = "morocco.png", AwayFlag = "croatia.png", Time = "02:00", Venue = "Levi's Stadium, San Francisco", Date = "Jun 21", Round = "Group F" },
            new() { Id = 13, HomeTeam = "France", AwayTeam = "Japan", HomeFlag = "france.png", AwayFlag = "japan.png", Time = "15:00", Venue = "BC Place, Vancouver", Date = "Jun 21", Round = "Group D" }
        };
    }

    public static ObservableCollection<Match> GetRecentResults()
    {
        return new ObservableCollection<Match>
        {
            new() { Id = 20, HomeTeam = "Portugal", AwayTeam = "Ghana", HomeFlag = "portugal.png", AwayFlag = "ghana.png", HomeScore = 3, AwayScore = 2, Status = "FT", Venue = "Estadio BBVA, Monterrey", Date = "Jun 18", Minute = "FT" },
            new() { Id = 21, HomeTeam = "Argentina", AwayTeam = "Saudi Arabia", HomeFlag = "argentina.png", AwayFlag = "saudi.png", HomeScore = 1, AwayScore = 2, Status = "FT", Venue = "Lusail Stadium, Lusail", Date = "Jun 18", Minute = "FT" }
        };
    }

    public static ObservableCollection<Standing> GetStandings()
    {
        return new ObservableCollection<Standing>
        {
            new() { Rank = 1, TeamName = "Iraq", TeamFlag = "iraq.png", Played = 2, Won = 2, Drawn = 0, Lost = 0, GoalsFor = 5, GoalsAgainst = 1, Points = 6, Form = "WW", GroupName = "Group A" },
            new() { Rank = 2, TeamName = "Argentina", TeamFlag = "argentina.png", Played = 2, Won = 1, Drawn = 1, Lost = 0, GoalsFor = 3, GoalsAgainst = 1, Points = 4, Form = "WD", GroupName = "Group A" },
            new() { Rank = 3, TeamName = "Netherlands", TeamFlag = "netherlands.png", Played = 2, Won = 0, Drawn = 1, Lost = 1, GoalsFor = 1, GoalsAgainst = 3, Points = 1, Form = "DL", GroupName = "Group A" },
            new() { Rank = 4, TeamName = "Senegal", TeamFlag = "senegal.png", Played = 2, Won = 0, Drawn = 0, Lost = 2, GoalsFor = 0, GoalsAgainst = 4, Points = 0, Form = "LL", GroupName = "Group A" }
        };
    }

    public static ObservableCollection<Standing> GetAllGroupStandings()
    {
        var all = new ObservableCollection<Standing>();
        all.Add(new() { Rank = 1, TeamName = "Iraq", TeamFlag = "iraq.png", Played = 2, Won = 2, Drawn = 0, Lost = 0, GoalsFor = 5, GoalsAgainst = 1, Points = 6, Form = "WW", GroupName = "Group A" });
        all.Add(new() { Rank = 2, TeamName = "Argentina", TeamFlag = "argentina.png", Played = 2, Won = 1, Drawn = 1, Lost = 0, GoalsFor = 3, GoalsAgainst = 1, Points = 4, Form = "WD", GroupName = "Group A" });
        all.Add(new() { Rank = 3, TeamName = "Netherlands", TeamFlag = "netherlands.png", Played = 2, Won = 0, Drawn = 1, Lost = 1, GoalsFor = 1, GoalsAgainst = 3, Points = 1, Form = "DL", GroupName = "Group A" });
        all.Add(new() { Rank = 4, TeamName = "Senegal", TeamFlag = "senegal.png", Played = 2, Won = 0, Drawn = 0, Lost = 2, GoalsFor = 0, GoalsAgainst = 4, Points = 0, Form = "LL", GroupName = "Group A" });
        all.Add(new() { Rank = 1, TeamName = "England", TeamFlag = "england.png", Played = 2, Won = 2, Drawn = 0, Lost = 0, GoalsFor = 6, GoalsAgainst = 2, Points = 6, Form = "WW", GroupName = "Group B" });
        all.Add(new() { Rank = 2, TeamName = "Iran", TeamFlag = "iran.png", Played = 2, Won = 1, Drawn = 0, Lost = 1, GoalsFor = 3, GoalsAgainst = 4, Points = 3, Form = "WL", GroupName = "Group B" });
        all.Add(new() { Rank = 3, TeamName = "USA", TeamFlag = "usa.png", Played = 2, Won = 0, Drawn = 1, Lost = 1, GoalsFor = 1, GoalsAgainst = 2, Points = 1, Form = "DL", GroupName = "Group B" });
        all.Add(new() { Rank = 4, TeamName = "Wales", TeamFlag = "wales.png", Played = 2, Won = 0, Drawn = 1, Lost = 1, GoalsFor = 2, GoalsAgainst = 4, Points = 1, Form = "LD", GroupName = "Group B" });
        return all;
    }

    public static ObservableCollection<TimelineItem> GetTimeline()
    {
        return new ObservableCollection<TimelineItem>
        {
            new() { Era = "SUMER", Year = "c. 4500 BCE", Title = "Cradle of Civilization", Description = "The world's first cities emerge in southern Mesopotamia. The Sumerians invent cuneiform writing, the wheel, and the first legal codes — laying the foundation for all future civilizations.", IconGlyph = "🏛", ColorHex = "#C9A84C" },
            new() { Era = "AKKAD", Year = "2334 BCE", Title = "The First Empire", Description = "Sargon of Akkad creates history's first true empire, uniting Sumer and Akkad. Trade routes stretch from the Mediterranean to the Persian Gulf.", IconGlyph = "⚔", ColorHex = "#B85D3F" },
            new() { Era = "BABYLON", Year = "1792 BCE", Title = "Hammurabi's Code", Description = "King Hammurabi establishes one of the earliest and most complete legal codes: 'An eye for an eye.' Babylon becomes the world's greatest city.", IconGlyph = "⚖", ColorHex = "#1F4E8C" },
            new() { Era = "NEO-BABYLON", Year = "604 BCE", Title = "The Golden City", Description = "Nebuchadnezzar II builds the legendary Hanging Gardens and the magnificent Ishtar Gate — adorned with blue glazed bricks and lion reliefs, one of the wonders of the ancient world.", IconGlyph = "🦁", ColorHex = "#C9A84C" },
            new() { Era = "BAGHDAD", Year = "762 CE", Title = "Center of the World", Description = "The Abbasid Caliphate builds Baghdad as a round city of knowledge. The House of Wisdom preserves ancient texts, advances mathematics, astronomy, and medicine.", IconGlyph = "📖", ColorHex = "#1F4E8C" },
            new() { Era = "MODERN IRAQ", Year = "1932", Title = "Independence & Football", Description = "Iraq gains independence. Football becomes the nation's passion. The Iraqi national team wins the 2007 AFC Asian Cup — a golden moment of unity and pride.", IconGlyph = "⚽", ColorHex = "#B85D3F" },
            new() { Era = "2026", Year = "NOW", Title = "World Cup 2026", Description = "The world's greatest tournament arrives in North America. 48 nations compete across USA, Canada, and Mexico. Babylon Score brings every moment live.", IconGlyph = "🏆", ColorHex = "#C9A84C" }
        };
    }
}
