using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using JsonExercise;
using System.Security.Policy;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);




var repo = new DapperDepartmentRepository(conn);


while (true)
{
    Console.WriteLine("Do you want to see the departments table? (yes/no)");
    string seeDep = Console.ReadLine();

    if (seeDep.ToLower() == "yes")
    {

        var departments = repo.GetAllDepartments();

        foreach (var department in departments)
        {
            Console.WriteLine($"Department ID: {department.DepartmentID}; Department Name: {department.Name}.");
        }

        break;
    }
    else if (seeDep.ToLower() == "no")
    {
        Console.WriteLine("Alright... Lets keep going!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid input... Please try again!");
    }
}



static void DepartmentUpdDelAdd(DapperDepartmentRepository? repo)
{

    Console.WriteLine("Would you like to (update/delete/add) a name on the departments table?");
    string seeDepTab = Console.ReadLine();

    if (seeDepTab.ToLower() == "update")
    {
        while (true)
        {
            Console.WriteLine("Enter the department ID of the name that you want to update here:");
            bool isItInt = int.TryParse(Console.ReadLine(), out int updDepID);
            if (isItInt == true)
            {
                Console.WriteLine("Enter the new name of the department that you are updating:");
                string updDepName = Console.ReadLine();

                repo.UpdateDepartment(updDepID, updDepName);
                var deppers = repo.GetAllDepartments();

                foreach (var dep in deppers)
                {
                    Console.WriteLine($"Department ID: {dep.DepartmentID}; Department Name: {dep.Name}.");
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input... Please try again!");
            }
        }
    }
    else if (seeDepTab.ToLower() == "delete")
    {
        while (true)
        {
            Console.WriteLine("Enter the department ID of the name that you want to remove here:");
            bool isItInt = int.TryParse(Console.ReadLine(), out int delDepID);
            if (isItInt == true)
            {
                repo.DeleteDepartment(delDepID);
                var deppers = repo.GetAllDepartments();

                foreach (var dep in deppers)
                {
                    Console.WriteLine($"Department ID: {dep.DepartmentID}; Department Name: {dep.Name}.");
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input... Please try again!");
            }
        }

    }
    else if (seeDepTab.ToLower() == "add")
    {

        Console.WriteLine("Enter the department name that you want to add here:");
        string addDepName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Enter the department ID of the name that you want to add here (cannot be an existing departmentID):");
            bool isItInt = int.TryParse(Console.ReadLine(), out int addDepID);
            if (isItInt == true)
            {

                repo.InsertDepartment(addDepName, addDepID);
                var deppers = repo.GetAllDepartments();

                foreach (var dep in deppers)
                {
                    Console.WriteLine($"Department ID: {dep.DepartmentID}; Department Name: {dep.Name}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input... Please try again!");
            }
        }

    }
    else if (seeDepTab.ToLower() == "no")
    {
        Console.WriteLine("Alright! Lets continue...");
    }
    else
    {
        Console.WriteLine("Invalid input... Please try again!");
        DepartmentUpdDelAdd(repo);
    }


    while (true)
    {
        Console.WriteLine("Do you want to keep going? (yes/no)");
        string restarter = Console.ReadLine();
        if (restarter.ToLower() == "yes")
        {
            DepartmentUpdDelAdd(repo);
            Console.Clear();
        }
        else if (restarter.ToLower() == "no")
        {
            Console.WriteLine("Thanks for coming... Have a great day!");
        }
        else
        {
            Console.WriteLine("Invalid input... Please try again!");
        }
    }
}

DepartmentUpdDelAdd(repo);













//var ProductRepo = new DapperProductRepository(conn);

//Console.WriteLine("Here is the product list:");
//var products = ProductRepo.GetAllProducts();

//foreach (var product in products)
//{
//    Console.WriteLine($"Product ID: {product.ProductID}; Product Name: {product.Name}; Product ID: {product.Price}; Product ID: {product.CategoryID}; Is Product On Sale: {product.OnSale}; Stock Level: {product.StockLevel};");
//    Console.WriteLine();
//    Console.WriteLine();
//}

