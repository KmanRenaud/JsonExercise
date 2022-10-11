using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise;
internal class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
    }
    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@name);",
         new { name = newDepartmentName});
    }
    public void InsertDepartment(string newDepartmentName, int newDepartmentID)
    {
        _connection.Execute("INSERT INTO DEPARTMENTS (DepartmentID, Name) VALUES (@departmentID, @name);",
         new { name = newDepartmentName, departmentID = newDepartmentID });
    }
    public void DeleteDepartment(int departmentID)
    {
        _connection.Execute("DELETE FROM departments WHERE departmentID = @departmentID;",
         new { departmentID });
    }
    public void UpdateDepartment(int newDepartmentID, string newName)
    {
        _connection.Execute("UPDATE departments SET Name = (@departmentName) WHERE departmentID = @departmentID;",
         new { departmentID = newDepartmentID, departmentName = newName});
    }

}