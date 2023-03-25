using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using EmployeeApp.Models;
using EmployeeApp.Pages;

namespace EmployeeApp.ViewModels;

public partial class EmployeeViewModel : BaseViewModel
{

    private readonly IEmployeeService service;

    public EmployeeViewModel(IEmployeeService service)
    {
        Employees = Task.Run(async () => await service.GetAll())
            .Result;

        this.service = service;
    }

    public ObservableCollection<Employee> Employees { get; }




    [RelayCommand]
    async void GoToDetailsAsync(Employee employee)
    {
        if (employee is null) employee = new Employee();
        await GoToDetails(employee);
    }

    private async Task GoToDetails(Employee employee)
    {
        await Shell.Current.GoToAsync(nameof(EmployeesDetailsPage), true,
            new Dictionary<string, object>
            {
                { nameof(Employee), employee }
            });
    }

    [RelayCommand]
    async void DisplayAction(Employee employee)
    {
        var result = await Shell.Current
             .DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
        if (result == "Edit")
        {
            await GoToDetails(employee);
        }
        else if (result == "Delete")
        {
            await service.Delete(employee.Id);
            InitEmployees();
        }

    }

    [RelayCommand]
    async void RightSwiped(int id)
    {
        var popup = new Popup()
        {
            Content = new VerticalStackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "确定删除吗?"
                    }
                }
            }
        };

        var result = await Shell.Current.ShowPopupAsync(popup);
    }

    [RelayCommand]
    async void InitEmployees()
    {
        var employees = await service.GetAll();
        Employees.Clear();
        foreach (var item in employees)
        {
            Employees.Add(item);
        }
    }

}