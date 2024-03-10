using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoRealm.Contract;
using TodoRealm.Data;
using TodoRealm.ViewModels;
using TodoRealm.Views;

namespace TodoRealm;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<TodoListPage>();
        builder.Services.AddTransient<TodoListViewModel>();
        builder.Services.AddTransient<TodoItemPage>();
        builder.Services.AddTransient<TodoItemViewModel>();
        builder.Services.AddSingleton<ITodoItemDatabase, TodoItemDatabase>();

        return builder.Build();
    }
}