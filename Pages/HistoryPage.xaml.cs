using BabylonScore.Models;
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
        LocalizationManager.Instance.LanguageChanged += (s, e) => LoadTimeline();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTimeline();
    }

    private void LoadTimeline()
    {
        var isAr = LocalizationManager.Instance.IsArabic;
        var list = MockDataStore.GetTimeline();

        var translated = list.Select(item => new TimelineItem
        {
            ColorHex = item.ColorHex,
            IconGlyph = item.IconGlyph,
            Era = isAr ? TranslateEra(item.Era) : item.Era,
            Year = isAr ? TranslateYear(item.Year) : item.Year,
            Title = isAr ? TranslateTitle(item.Title) : item.Title,
            Description = isAr ? TranslateDesc(item.Title, item.Description) : item.Description
        }).ToList();

        TimelineList.ItemsSource = translated;
    }

    private string TranslateEra(string era)
    {
        return era switch
        {
            "SUMER" => "سومر",
            "AKKAD" => "أكاد",
            "BABYLON" => "بابل",
            "NEO-BABYLON" => "بابل الحديثة",
            "BAGHDAD" => "بغداد",
            "MODERN IRAQ" => "العراق الحديث",
            "2026" => "٢٠٢٦",
            _ => era
        };
    }

    private string TranslateYear(string yr)
    {
        return yr.Replace("c. 4500 BCE", "٤٥٠٠ ق.م")
                 .Replace("2334 BCE", "٢٣٣٤ ق.م")
                 .Replace("1792 BCE", "١٧٩٢ ق.م")
                 .Replace("604 BCE", "٦٠٤ ق.م")
                 .Replace("762 CE", "٧٦٢ م")
                 .Replace("1932", "١٩٣٢ م")
                 .Replace("NOW", "الآن");
    }

    private string TranslateTitle(string title)
    {
        return title switch
        {
            "Cradle of Civilization" => "مهد الحضارة",
            "The First Empire" => "الإمبراطورية الأولى",
            "Hammurabi's Code" => "شريعة حمورابي",
            "The Golden City" => "المدينة الذهبية",
            "Center of the World" => "مركز العالم",
            "Independence & Football" => "الاستقلال وكرة القدم",
            "World Cup 2026" => "كأس العالم ٢٠٢٦",
            _ => title
        };
    }

    private string TranslateDesc(string title, string defaultDesc)
    {
        return title switch
        {
            "Cradle of Civilization" => "تظهر المدن الأولى في العالم في جنوب بلاد الرافدين. اخترع السومريون الكتابة المسمارية، العجلة، وأول القوانين القانونية.",
            "The First Empire" => "سرجون الأكادي يؤسس أول إمبراطورية حقيقية في التاريخ، ويوحد سومر وأكاد لتصل طرق التجارة إلى الخليج العربي.",
            "Hammurabi's Code" => "الملك حمورابي يضع أحد أقدم القوانين وأكثرها اكتمالاً: 'العين بالعين'. تصبح بابل أعظم مدينة في العالم القديم.",
            "The Golden City" => "نبوخذ نصر الثاني يبني حدائق بابل المعلقة وبوابة عشتار الشهيرة المزينة بالطوب الأزرق المزجج ونقوش الأسود.",
            "Center of the World" => "الخلافة العباسية تبني بغداد كمدينة دائرية للمعرفة. وبيت الحكمة يحفظ النصوص القديمة ويطور الرياضيات والطب.",
            "Independence & Football" => "العراق ينال استقلاله وتصبح كرة القدم شغف الأمة. يحقق المنتخب العراقي فوزاً تاريخياً بكأس آسيا ٢٠٠٧.",
            "World Cup 2026" => "البطولة الأكبر في العالم تصل إلى أمريكا الشمالية. ٤٨ دولة تتنافس في كندا، المكسيك، والولايات المتحدة الأمريكية.",
            _ => defaultDesc
        };
    }
}
