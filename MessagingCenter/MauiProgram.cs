﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MessagingCenter;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}