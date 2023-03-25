using EmployeeApp.Pages;

namespace EmployeeApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(EmployeesDetailsPage), typeof(EmployeesDetailsPage));
    }
}