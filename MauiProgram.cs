using BabylonScore.Pages;
using Microsoft.Extensions.Logging;

namespace BabylonScore;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<MatchesPage>();
        builder.Services.AddTransient<TablePage>();
        builder.Services.AddTransient<HistoryPage>();
        builder.Services.AddTransient<MatchDetailPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
