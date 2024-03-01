using HexoBlog.Service;
using Microsoft.Extensions.Logging;

namespace HexoBlog
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<ClassifyService>();
            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://www.60points.com/api") });
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
