
using SQLite;

namespace EmployeeApp.Models;

public class Employee
{
    [PrimaryKey, AutoIncrement] 
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public byte Gender { get; set; }

    public bool Deleted { get; set; }

    public void Delete()
    {
        this.Deleted = true;
    }

    public DateTime BirthDay { get; set; }
}