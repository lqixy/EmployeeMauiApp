using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class MainPage : ContentPage
{
    public EmployeeViewModel _viewModel;

    public MainPage(EmployeeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        {
            _viewModel.InitEmployeesCommand.Execute(null);
        }
    }


}