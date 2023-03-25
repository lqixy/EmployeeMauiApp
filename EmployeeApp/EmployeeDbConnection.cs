using System;
using Microsoft.Extensions.Configuration;
using SQLite;

namespace EmployeeApp
{
    public class EmployeeDbConnection
    {
        //private readonly IConfiguration configuration;
        public SQLiteConnection Db;

        public EmployeeDbConnection(IConfiguration configuration)
        {
            Db = new SQLiteConnection(configuration["ConnectionStrings:Default"]);

            //this.configuration = configuration;
        }
    }
}

