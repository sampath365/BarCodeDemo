using Microsoft.Extensions.Logging;

using ZXing.Net.Maui.Controls;
using CommunityToolkit.Maui;
using BarCodeDemo.ApService;
using BarCodeDemo.ViewCommands;
using FFImageLoading.Maui;

namespace BarCodeDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                 .UseFFImageLoading()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<BarcodeScanPage>();
            builder.Services.AddHttpClient<IApiService, ApiService>();
            builder.Services.AddTransient<MovieViewModel>();

            builder.Services.AddTransient<MovieDetailViewModel>();
            builder.Services.AddTransient<SearchPage>();
            builder.Services.AddTransient<MovieDetailPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}