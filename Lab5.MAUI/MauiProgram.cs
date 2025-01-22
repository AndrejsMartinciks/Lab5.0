using CommunityToolkit.Maui;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;
using Lab5.MAUI.ViewModels;
using Microsoft.Extensions.Logging;

namespace Lab5.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddScoped<IAuthorApiClient, AuthorApiClient>();
            builder.Services.AddScoped<IDataRepository, ApiDataRepository>();

            builder.Services.AddSingleton<Lab5.MAUI.ViewModels.MainPageViewModel>();
            builder.Services.AddScoped<Lab5.MAUI.ViewModels.BooksPageViewModel>();
            builder.Services.AddSingleton<Lab5.MAUI.MainPage>();
            builder.Services.AddSingleton<BooksPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
