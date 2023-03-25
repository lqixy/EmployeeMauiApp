using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.Models;
using CommunityToolkit.Maui.Alerts;

namespace EmployeeApp.ViewModels
{
    [QueryProperty(nameof(Employee), "Employee")]
    public partial class EmployeeDetailsViewModel : BaseViewModel
    {
        private readonly IEmployeeService service;
        public EmployeeDetailsViewModel(IEmployeeService service)
        {
            this.service = service;
        }

        [ObservableProperty]
        Employee employee;

        [RelayCommand]
        async void DeleteAsync(int id)
        {
            if(id == 0)
            {
               var toast = Toast.Make("无法删除未创建的信息!", CommunityToolkit.Maui.Core.ToastDuration.Short);
               await toast.Show();
                return;
            }
            await service.Delete(id);

            await GoToMain();
        }

        [RelayCommand]
        async void SaveAsync(Employee employee)
        {
            if (employee is null)
            {
                var toast = Toast.Make("员工信息有误!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();
                return;
            }
            await service.Save(employee);

            await GoToMain();
        }

        [RelayCommand]
        async void CancelAsync()
        {
            await GoToMain();
        }

        async Task GoToMain()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

