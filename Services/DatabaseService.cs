using System.Collections.ObjectModel;
using System.Text.Json;
using BabylonScore.Models;

namespace BabylonScore.Services;

public class DatabaseService
{
    private static DatabaseService? _instance;
    public static DatabaseService Instance => _instance ??= new DatabaseService();

    private readonly string _filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "babylon_data.json");

    public ObservableCollection<Match> Matches { get; set; } = new();
    public ObservableCollection<NewsArticle> Articles { get; set; } = new();
    public ObservableCollection<Standing> Standings { get; set; } = new();

    private DatabaseService()
    {
        LoadData();
    }

    public void SaveData()
    {
        try
        {
            var data = new AppDataWrapper
            {
                Matches = Matches.ToList(),
                Articles = Articles.ToList(),
                Standings = Standings.ToList()
            };
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to save data: {ex.Message}");
        }
    }

    public void LoadData()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<AppDataWrapper>(json);
                if (data != null)
                {
                    Matches = new ObservableCollection<Match>(data.Matches ?? new());
                    Articles = new ObservableCollection<NewsArticle>(data.Articles ?? new());
                    Standings = new ObservableCollection<Standing>(data.Standings ?? new());
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to load data, using seeds: {ex.Message}");
        }

        SeedInitialData();
    }

    private void SeedInitialData()
    {
        // Seeding matches
        Matches = new ObservableCollection<Match>
        {
            new()
            {
                Id = 1, HomeTeam = "Iraq", HomeTeamAr = "العراق",
                AwayTeam = "Argentina", AwayTeamAr = "الأرجنتين",
                HomeFlag = "iraq.png", AwayFlag = "argentina.png",
                HomeScore = 2, AwayScore = 1,
                Minute = "Live • 84'", MinuteAr = "مباشر • 84'", Status = "Live", StatusAr = "مباشر",
                Venue = "Ishtar Arena, Babylon", VenueAr = "ملعب عشتار، بابل",
                Round = "Group A", RoundAr = "المجموعة الأولى",
                Date = "Jun 19", DateAr = "19 حزيران",
                Time = "19:00", TimeAr = "19:00",
                LeagueName = "World Cup 2026", LeagueNameAr = "كأس العالم 2026",
                HomePossession = 48, AwayPossession = 52,
                HomeShots = 11, AwayShots = 9,
                HomeShotsOnTarget = 5, AwayShotsOnTarget = 4,
                HomeCorners = 4, AwayCorners = 6,
                HomeFouls = 12, AwayFouls = 10,
                HomeYellowCards = 2, AwayYellowCards = 1,
                HomeRedCards = 0, AwayRedCards = 0,
                GroupName = "Group A", GroupNameAr = "المجموعة أ",
                Events = new List<MatchEvent>
                {
                    new() { Minute = 12, Type = "Goal", PlayerName = "Aymen Hussein", Team = "Home", Detail = "Header, Assist by Ali Jasim" },
                    new() { Minute = 44, Type = "YellowCard", PlayerName = "Amir Al-Ammari", Team = "Home", Detail = "Tactical foul" },
                    new() { Minute = 60, Type = "Goal", PlayerName = "Lionel Messi", Team = "Away", Detail = "Penalty kick" },
                    new() { Minute = 78, Type = "Goal", PlayerName = "Ali Jasim", Team = "Home", Detail = "Brilliant solo run & shot" }
                }
            },
            new()
            {
                Id = 2, HomeTeam = "Brazil", HomeTeamAr = "البرازيل",
                AwayTeam = "Germany", AwayTeamAr = "ألمانيا",
                HomeFlag = "brazil.png", AwayFlag = "germany.png",
                HomeScore = 1, AwayScore = 1,
                Minute = "Live • 40'", MinuteAr = "مباشر • 40'", Status = "Live", StatusAr = "مباشر",
                Venue = "Sumer International Pitch, Ur", VenueAr = "ملعب سومر الدولي، أور",
                Round = "Group B", RoundAr = "المجموعة الثانية",
                Date = "Jun 19", DateAr = "19 حزيران",
                Time = "21:30", TimeAr = "21:30",
                LeagueName = "World Cup 2026", LeagueNameAr = "كأس العالم 2026",
                HomePossession = 57, AwayPossession = 43,
                HomeShots = 7, AwayShots = 5,
                HomeShotsOnTarget = 3, AwayShotsOnTarget = 2,
                HomeCorners = 5, AwayCorners = 3,
                HomeFouls = 8, AwayFouls = 14,
                HomeYellowCards = 1, AwayYellowCards = 3,
                HomeRedCards = 0, AwayRedCards = 0,
                GroupName = "Group B", GroupNameAr = "المجموعة ب",
                Events = new List<MatchEvent>
                {
                    new() { Minute = 22, Type = "Goal", PlayerName = "Vinicius Jr", Team = "Home", Detail = "Assist by Rodrygo" },
                    new() { Minute = 35, Type = "Goal", PlayerName = "Florian Wirtz", Team = "Away", Detail = "Long range strike" }
                }
            },
            new()
            {
                Id = 3, HomeTeam = "Al-Shorta", HomeTeamAr = "الشرطة",
                AwayTeam = "Al-Quwa Al-Jawiya", AwayTeamAr = "القوة الجوية",
                HomeFlag = "alshorta.png", AwayFlag = "aljawiya.png",
                HomeScore = 0, AwayScore = 0,
                Minute = "Live • 12'", MinuteAr = "مباشر • 12'", Status = "Live", StatusAr = "مباشر",
                Venue = "Al-Shaab Stadium, Baghdad", VenueAr = "ملعب الشعب، بغداد",
                Round = "Round 28", RoundAr = "الجولة 28",
                Date = "Jun 19", DateAr = "19 حزيران",
                Time = "18:00", TimeAr = "18:00",
                LeagueName = "Iraq Stars League", LeagueNameAr = "دوري نجوم العراق",
                HomePossession = 50, AwayPossession = 50,
                HomeShots = 2, AwayShots = 1,
                HomeShotsOnTarget = 0, AwayShotsOnTarget = 0,
                HomeCorners = 1, AwayCorners = 1,
                HomeFouls = 4, AwayFouls = 5,
                HomeYellowCards = 0, AwayYellowCards = 0,
                HomeRedCards = 0, AwayRedCards = 0,
                GroupName = "League", GroupNameAr = "الدوري",
                Events = new List<MatchEvent>()
            },
            new()
            {
                Id = 4, HomeTeam = "Real Madrid", HomeTeamAr = "ريال مدريد",
                AwayTeam = "Barcelona", AwayTeamAr = "برشلونة",
                HomeFlag = "realmadrid.png", AwayFlag = "barcelona.png",
                HomeScore = null, AwayScore = null,
                Minute = "Scheduled", MinuteAr = "مجدولة", Status = "Scheduled", StatusAr = "مجدولة",
                Venue = "Santiago Bernabéu, Madrid", VenueAr = "سانتياغو برنابيو، مدريد",
                Round = "Final", RoundAr = "النهائي",
                Date = "Jun 20", DateAr = "20 حزيران",
                Time = "22:00", TimeAr = "22:00",
                LeagueName = "UEFA Champions League", LeagueNameAr = "دوري أبطال أوروبا",
                HomePossession = 0, AwayPossession = 0,
                HomeShots = 0, AwayShots = 0,
                GroupName = "Knockout", GroupNameAr = "الأدوار الإقصائية",
                Events = new List<MatchEvent>()
            },
            new()
            {
                Id = 5, HomeTeam = "England", HomeTeamAr = "إنجلترا",
                AwayTeam = "France", AwayTeamAr = "فرنسا",
                HomeFlag = "england.png", AwayFlag = "france.png",
                HomeScore = 2, AwayScore = 3,
                Minute = "FT", MinuteAr = "انتهت", Status = "FT", StatusAr = "انتهت",
                Venue = "Wembley Stadium, London", VenueAr = "ملعب ويمبلي، لندن",
                Round = "Friendly", RoundAr = "ودية",
                Date = "Jun 18", DateAr = "18 حزيران",
                Time = "20:00", TimeAr = "20:00",
                LeagueName = "International Friendly", LeagueNameAr = "مباراة ودية دولية",
                HomePossession = 45, AwayPossession = 55,
                HomeShots = 12, AwayShots = 15,
                HomeShotsOnTarget = 5, AwayShotsOnTarget = 8,
                HomeCorners = 4, AwayCorners = 7,
                HomeFouls = 10, AwayFouls = 9,
                HomeYellowCards = 1, AwayYellowCards = 1,
                HomeRedCards = 0, AwayRedCards = 0,
                GroupName = "Friendly", GroupNameAr = "ودية",
                Events = new List<MatchEvent>
                {
                    new() { Minute = 14, Type = "Goal", PlayerName = "Kylian Mbappé", Team = "Away", Detail = "Power shot" },
                    new() { Minute = 32, Type = "Goal", PlayerName = "Harry Kane", Team = "Home", Detail = "Header" },
                    new() { Minute = 55, Type = "Goal", PlayerName = "Jude Bellingham", Team = "Home", Detail = "Volley shot" },
                    new() { Minute = 72, Type = "Goal", PlayerName = "Antoine Griezmann", Team = "Away", Detail = "Chip over keeper" },
                    new() { Minute = 89, Type = "Goal", PlayerName = "Kylian Mbappé", Team = "Away", Detail = "Solo counter-attack goal" }
                }
            }
        };

        // Seeding News/Transfers
        Articles = new ObservableCollection<NewsArticle>
        {
            new()
            {
                Id = 1,
                Title = "Iraqi Legend Ali Jasim completes dream transfer to Serie A!",
                TitleAr = "الأسطورة العراقي علي جاسم يكمل انتقاله التاريخي إلى الكالتشيو الإيطالي!",
                Summary = "Ali Jasim signs a 5-year contract with Como in Serie A under Cesc Fàbregas. The Mesopotamian jewel is set to shine on the European stage.",
                SummaryAr = "علي جاسم يوقع عقداً لمدة 5 سنوات مع نادي كومو في الدوري الإيطالي تحت قيادة سيسك فابريغاس. جوهرة بلاد الرافدين تستعد للتألق أوروبياً.",
                Content = "The highly rated Iraqi winger Ali Jasim has officially completed his transfer. His incredible performance in the AFC U-23 Asian Cup and with the national team caught the eyes of European scouts. Cesc Fàbregas expressed absolute delight in signing the Iraqi talent, expecting him to be a key playmaker for Como in their top-flight journey.",
                ContentAr = "أكمل الجناح العراقي الشاب علي جاسم انتقاله رسمياً. الأداء المذهل الذي قدمه في كأس آسيا تحت 23 عاماً ومع المنتخب الوطني لفت أنظار الكشافين الأوروبيين. وعبر سيسك فابريغاس عن سعادته المطلقة بالتعاقد مع الموهبة العراقية، متوقعاً أن يكون صانع ألعاب رئيسي لكومو في رحلتهم بالدرجة الأولى.",
                Category = "Transfer",
                CategoryAr = "انتقالات",
                Timestamp = "2 hours ago",
                TimestampAr = "قبل ساعتين",
                ImageUrl = "iraq_flag.png"
            },
            new()
            {
                Id = 2,
                Title = "Mesopotamian Stadiums ready to host Arab Gulf Cup!",
                TitleAr = "ملاعب بلاد الرافدين جاهزة تماماً لاستضافة كأس الخليج العربي!",
                Summary = "Basra International Stadium and Minaa Stadium undergo stunning luxury upgrades ahead of the regional football festival.",
                SummaryAr = "ملعب البصرة الدولي وملعب الميناء يشهدان ترقيات فاخرة مذهلة تمهيداً لانطلاق مهرجان كرة القدم الإقليمي.",
                Content = "Iraq is once again demonstrating its capacity to host major international football events. The Ministry of Youth and Sports confirmed that all stadiums are fully ready. The designs blend ancient Mesopotamian architecture with futuristic stadium technologies, giving visiting fans an unforgettable experience.",
                ContentAr = "يثبت العراق مجدداً قدرته على استضافة الأحداث الرياضية الدولية الكبرى. وأكدت وزارة الشباب والرياضة جاهزية الملاعب تماماً. وتدمج التصاميم بين عمارة بلاد الرافدين القديمة وتقنيات الملاعب المستقبلية، مما يمنح الجماهير الزائرة تجربة لا تُنسى.",
                Category = "News",
                CategoryAr = "أخبار",
                Timestamp = "1 day ago",
                TimestampAr = "قبل يوم واحد",
                ImageUrl = "iraq_stadium.png"
            }
        };

        // Seeding Standings for Group A (World Cup 2026)
        Standings = new ObservableCollection<Standing>
        {
            new() { Rank = 1, TeamName = "Iraq", TeamFlag = "iraq.png", Played = 2, Won = 2, Drawn = 0, Lost = 0, GoalsFor = 5, GoalsAgainst = 1, Points = 6, Form = "WW", GroupName = "Group A" },
            new() { Rank = 2, TeamName = "Argentina", TeamFlag = "argentina.png", Played = 2, Won = 1, Drawn = 1, Lost = 0, GoalsFor = 3, GoalsAgainst = 1, Points = 4, Form = "WD", GroupName = "Group A" },
            new() { Rank = 3, TeamName = "Netherlands", TeamFlag = "netherlands.png", Played = 2, Won = 0, Drawn = 1, Lost = 1, GoalsFor = 1, GoalsAgainst = 3, Points = 1, Form = "DL", GroupName = "Group A" },
            new() { Rank = 4, TeamName = "Senegal", TeamFlag = "senegal.png", Played = 2, Won = 0, Drawn = 0, Lost = 2, GoalsFor = 0, GoalsAgainst = 4, Points = 0, Form = "LL", GroupName = "Group A" }
        };

        SaveData();
    }

    private class AppDataWrapper
    {
        public List<Match>? Matches { get; set; }
        public List<NewsArticle>? Articles { get; set; }
        public List<Standing>? Standings { get; set; }
    }
}
