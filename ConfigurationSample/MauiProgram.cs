using System.Reflection;
using ConfigurationSample.Extensions;
using ConfigurationSample.Model;
using ConfigurationSample.View;
using ConfigurationSample.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace ConfigurationSample;

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
        
        // configuration support
        using var jsonConfigStream = new EmbeddedFileProvider(Assembly.GetExecutingAssembly())
            .GetFileInfo("appsettings.json")
            .CreateReadStream();
        var config = new ConfigurationBuilder()
            .AddJsonStream(jsonConfigStream)
#if (MACCATALYST || WINDOWS)
            .AddEnvironmentVariables()
            .AddCommandLine(Environment.GetCommandLineArgs())
#endif
            .Build();

        builder.Configuration.AddConfiguration(config);
        builder.Services.Configure<TransientFaultHandlingOptions>(
            config.GetSection(nameof(TransientFaultHandlingOptions)));

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        return builder.Build();
    }
}