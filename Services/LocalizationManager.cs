using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BabylonScore.Services;

public class LocalizationManager : INotifyPropertyChanged
{
    private static LocalizationManager? _instance;
    public static LocalizationManager Instance => _instance ??= new LocalizationManager();

    private string _currentLanguage = "en"; // "en" or "ar"

    public string CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            if (_currentLanguage != value)
            {
                _currentLanguage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsArabic));
                OnPropertyChanged(nameof(IsEnglish));
                OnPropertyChanged(nameof(FlowDirection));
                OnPropertyChanged(nameof(HorizontalOptionsLeftToRight));
                OnPropertyChanged(nameof(HorizontalOptionsRightToLeft));
                LanguageChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public bool IsArabic => _currentLanguage == "ar";
    public bool IsEnglish => _currentLanguage == "en";
    public Microsoft.Maui.FlowDirection FlowDirection => IsArabic ? Microsoft.Maui.FlowDirection.RightToLeft : Microsoft.Maui.FlowDirection.LeftToRight;
    public LayoutOptions HorizontalOptionsLeftToRight => IsArabic ? LayoutOptions.End : LayoutOptions.Start;
    public LayoutOptions HorizontalOptionsRightToLeft => IsArabic ? LayoutOptions.Start : LayoutOptions.End;

    public event EventHandler? LanguageChanged;

    private readonly Dictionary<string, Dictionary<string, string>> _translations = new()
    {
        { "en", new Dictionary<string, string>
            {
                { "AppName", "BABYLON SCORE" },
                { "Slogan", "Where History Meets the Beautiful Game" },
                { "CuneiformTitle", "𒀭 𒈗 𒀀 🦁 • MESOPOTAMIAN FOOTBALL CHRONICLES • 🏺 🏛 ⚔" },
                { "LiveNow", "LIVE MATCHES" },
                { "Upcoming", "UPCOMING FIXTURES" },
                { "RecentResults", "RECENT RESULTS" },
                { "TransfersNews", "LATEST TRANSFER NEWS" },
                { "WorldCupHub", "WORLD CUP 2026 HUB" },
                { "LanguageName", "العربية" },
                { "AdminPanel", "Admin Access" },
                { "Username", "Username" },
                { "Password", "Password" },
                { "Login", "Authenticate" },
                { "InvalidLogin", "Invalid username or password." },
                { "AdminDashboard", "CUNEIFORM CONTROL CENTRE" },
                { "SaveScore", "Publish Score & Stats" },
                { "LiveMinute", "Live Minute" },
                { "HomePossession", "Home Possession (%)" },
                { "AwayPossession", "Away Possession (%)" },
                { "HomeShots", "Home Shots" },
                { "AwayShots", "Away Shots" },
                { "Logout", "De-authorize" },
                { "SelectMatch", "Select Match to Edit" },
                { "AddNews", "Publish Transfer/News" },
                { "NewsTitle", "Title (EN)" },
                { "NewsTitleAr", "Title (AR)" },
                { "NewsContent", "Content (EN)" },
                { "NewsContentAr", "Content (AR)" },
                { "Publish", "Carve into Stone (Publish)" },
                { "Stats", "STATISTICS" },
                { "Possession", "Possession" },
                { "Shots", "Shots" },
                { "ShotsOnTarget", "Shots on Target" },
                { "Corners", "Corners" },
                { "Fouls", "Fouls" },
                { "YellowCards", "Yellow Cards" },
                { "RedCards", "Red Cards" },
                { "Timeline", "TIMELINE EVENTS" },
                { "Venue", "Venue" },
                { "Round", "Round" },
                { "HistoryHeader", "MESOPOTAMIAN TIMELINE" },
                { "HistorySub", "From cuneiform clay tablets to the World Cup pitch" },
                { "WorldCupGroups", "WORLD CUP GROUPS" },
                { "WorldCupTopScorers", "TOP SCORERS" },
                { "WorldCupMatches", "WORLD CUP MATCHES" },
                { "CopyrightText", "© BY MURTADA" },
                { "SumerEra", "SUMER" },
                { "AkkadEra", "AKKAD" },
                { "BabylonEra", "BABYLON" },
                { "NeoBabylonEra", "NEO-BABYLON" },
                { "BaghdadEra", "BAGHDAD" },
                { "ModernIraqEra", "MODERN IRAQ" },
                { "Wc26Era", "WORLD CUP 2026" },
                { "Back", "Back" }
            }
        },
        { "ar", new Dictionary<string, string>
            {
                { "AppName", "نـتـيـجـة بـابـل" },
                { "Slogan", "حيث يلتقي التاريخ باللعبة الجميلة" },
                { "CuneiformTitle", "𒀭 𒈗 𒀀 🦁 • سجلات كرة القدم الرافدينية • 🏺 🏛 ⚔" },
                { "LiveNow", "المباريات المباشرة" },
                { "Upcoming", "المباريات القادمة" },
                { "RecentResults", "النتائج الأخيرة" },
                { "TransfersNews", "أحدث أخبار الانتقالات" },
                { "WorldCupHub", "مركز كأس العالم 2026" },
                { "LanguageName", "English" },
                { "AdminPanel", "دخول المشرف" },
                { "Username", "اسم المستخدم" },
                { "Password", "كلمة المرور" },
                { "Login", "تسجيل الدخول" },
                { "InvalidLogin", "اسم المستخدم أو كلمة المرور غير صالحة." },
                { "AdminDashboard", "لوحة تحكم مسمارية" },
                { "SaveScore", "نشر النتيجة والإحصائيات" },
                { "LiveMinute", "الدقيقة المباشرة" },
                { "HomePossession", "استحواذ المضيف (%)" },
                { "AwayPossession", "استحواذ الضيف (%)" },
                { "HomeShots", "تسديدات المضيف" },
                { "AwayShots", "تسديدات الضيف" },
                { "Logout", "تسجيل الخروج" },
                { "SelectMatch", "اختر مباراة لتعديلها" },
                { "AddNews", "نشر خبر/انتقال جديد" },
                { "NewsTitle", "العنوان بالإنجليزية" },
                { "NewsTitleAr", "العنوان بالعربية" },
                { "NewsContent", "المحتوى بالإنجليزية" },
                { "NewsContentAr", "المحتوى بالعربية" },
                { "Publish", "نقش على الحجر (نشر)" },
                { "Stats", "الإحصائيات" },
                { "Possession", "الاستحواذ" },
                { "Shots", "التسديدات" },
                { "ShotsOnTarget", "التسديدات على المرمى" },
                { "Corners", "الضربات الركنية" },
                { "Fouls", "الأخطاء" },
                { "YellowCards", "البطاقات الصفراء" },
                { "RedCards", "البطاقات الحمراء" },
                { "Timeline", "أحداث المباراة" },
                { "Venue", "الملعب" },
                { "Round", "الجولة" },
                { "HistoryHeader", "التسلسل الزمني لبلاد الرافدين" },
                { "HistorySub", "من الألواح الطينية المسمارية إلى ملاعب كأس العالم" },
                { "WorldCupGroups", "مجموعات كأس العالم" },
                { "WorldCupTopScorers", "الهدافون" },
                { "WorldCupMatches", "مباريات كأس العالم" },
                { "CopyrightText", "© بواسطة مرتضى" },
                { "SumerEra", "سومر" },
                { "AkkadEra", "أكاد" },
                { "BabylonEra", "بابل" },
                { "NeoBabylonEra", "بابل الحديثة" },
                { "BaghdadEra", "بغداد" },
                { "ModernIraqEra", "العراق الحديث" },
                { "Wc26Era", "كأس العالم 2026" },
                { "Back", "الرجوع" }
            }
        }
    };

    public string this[string key]
    {
        get
        {
            if (_translations.TryGetValue(_currentLanguage, out var langDict) && langDict.TryGetValue(key, out var val))
            {
                return val;
            }
            return key;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
