using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using EmployeeApp.Models;
using SQLite;

namespace EmployeeApp
{
    public class EmployeeDatabase
    {
        SQLiteAsyncConnection Database;

        public EmployeeDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null) return;

            Database = new SQLiteAsyncConnection(Constants.DatabaseFilename, Constants.Flags);

            var result = await Database.CreateTableAsync<Employee>();
        }


        public async Task<List<Employee>> GetAll(Expression<Func<Employee, bool>> predExpr)
        {
            await Init();
            var entities = await Database.Table<Employee>()
                .Where(predExpr)
                .ToListAsync();
            return entities;
        }

        public async Task<Employee> GetById(int id)
        {
            await Init();
            return await Database.Table<Employee>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Employee entity)
        {
            await Init();
            if(entity.Id != 0)
            {
                return await Database.UpdateAsync(entity);
            }

            return await Database.InsertAsync(entity);
        }

        public async Task<int> Delete(Employee entity)
        {
            await Init();
            return await Database.DeleteAsync(entity);
        }
    }
}

