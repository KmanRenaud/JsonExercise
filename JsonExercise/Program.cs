using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using JsonExercise;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

Console.WriteLine("Enter the department name here:");
var input = Console.ReadLine();


repo.InsertDepartment(input);
var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine($"Department ID: {department.DepartmentID}; Department Name: {department.Name}.");
}

var ProductRepo = new DapperProductRepository(conn);

Console.WriteLine("Here is the product list:");
var products = ProductRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"Product ID: {product.ProductID}; Product Name: {product.ProductName}; Product ID: {product.Price}; Product ID: {product.CategoryID}; Is Product On Sale: {product.OnSale}; Stock Level: {product.StockLevel};");
    Console.WriteLine();
    Console.WriteLine();
}

