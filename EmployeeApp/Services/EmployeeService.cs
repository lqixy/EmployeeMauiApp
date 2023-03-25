using System;
using System.Collections.ObjectModel;
using EmployeeApp.Models;
using SQLite;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDatabase database;
        public EmployeeService(EmployeeDatabase database)
        {
            this.database = database;
        }

        //public async Task Add(Employee entity)
        //{
        //    await database.Save(entity);
        //}

        public async Task Save(Employee entity)
        {
            await database.Save(entity);
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            entity.Delete();
            await database.Save(entity);
        }

        //public async Task Update(Employee entity)
        //{
        //    await database.Save(entity);
        //}

        public async Task<ObservableCollection<Employee>> GetAll()
        {
            var entities = await database.GetAll(x => !x.Deleted);

            return new ObservableCollection<Employee>(entities);
        }

        public async Task<Employee> GetById(int id)
        {
            return await database.GetById(id);
        }
    }
}

