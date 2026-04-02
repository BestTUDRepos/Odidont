using Microsoft.Extensions.Logging;
using Odidont.Services;

namespace Odidont;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        
        builder.Services.AddSingleton<LessonService>();
        builder.Services.AddSingleton<CheckService>();
        builder.Services.AddSingleton<CheckStateService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}