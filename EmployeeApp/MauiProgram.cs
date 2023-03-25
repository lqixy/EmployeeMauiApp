global using EmployeeApp.Pages;
global using EmployeeApp.Services;
global using EmployeeApp.ViewModels;
global using Microsoft.Extensions.Logging;
global using CommunityToolkit.Maui;

namespace EmployeeApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<EmployeeViewModel>();
        builder.Services.AddTransient<EmployeeDetailsViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<EmployeesDetailsPage>();
        builder.Services.AddSingleton<EmployeeDatabase>();
        builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
        return builder.Build();
    }
}