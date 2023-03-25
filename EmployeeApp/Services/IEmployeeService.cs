using System;
using System.Collections.ObjectModel;
using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        Task Save(Employee entity);

        Task<ObservableCollection<Employee>> GetAll();

        Task<Employee> GetById(int id);

        //Task Add(Employee entity);

        Task Delete(int id);
    }
}

