using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public decimal MonthlySalary { get; set; }
    public double TaxRate { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; } = string.Empty;
}
class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1001;
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Employee Payroll System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ViewEmployees();
                    break;
                case "3":
                    UpdateEmployee();
                    break;
                case "4":
                    DeleteEmployee();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
    static void AddEmployee()
    {
        Employee newEmployee = new Employee();
        newEmployee.Id = nextId++;
        Console.Write("Enter First Name: ");
        newEmployee.FirstName = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Last Name: ");
        newEmployee.LastName = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Department: ");
        newEmployee.Department = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Job Title: ");
        newEmployee.JobTitle = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Monthly Salary: ");
        newEmployee.MonthlySalary = decimal.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter Tax Rate (as a decimal): ");
        newEmployee.TaxRate = double.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter Hire Date (yyyy-MM-dd): ");
        newEmployee.HireDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Is Active (true/false): ");
        newEmployee.IsActive = bool.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter Email: ");
        newEmployee.Email = Console.ReadLine() ?? string.Empty;

        employees.Add(newEmployee);
        Console.WriteLine("Employee added successfully!");
    }
    static void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("Employee List:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Job Title: {employee.JobTitle}, Monthly Salary: {employee.MonthlySalary:C}, Tax Rate: {employee.TaxRate:P}, Hire Date: {employee.HireDate.ToShortDateString()}, Active: {employee.IsActive}, Email: {employee.Email}");
        }
    }
    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write("Enter First Name (leave blank to keep current): ");
        string firstName = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(firstName))
            employee.FirstName = firstName;

        Console.Write("Enter Last Name (leave blank to keep current): ");
        string lastName = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(lastName))
            employee.LastName = lastName;

        Console.Write("Enter Department (leave blank to keep current): ");
        string department = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(department))
            employee.Department = department;

        Console.Write("Enter Job Title (leave blank to keep current): ");
        string jobTitle = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(jobTitle))
            employee.JobTitle = jobTitle;

        Console.Write("Enter Monthly Salary (leave blank to keep current): ");
        string salaryInput = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(salaryInput))
            employee.MonthlySalary = decimal.Parse(salaryInput);

        Console.Write("Enter Tax Rate (as a decimal, leave blank to keep current): ");
        string taxRateInput = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(taxRateInput))
            employee.TaxRate = double.Parse(taxRateInput);

        Console.Write("Enter Hire Date (yyyy-MM-dd, leave blank to keep current): ");
        string hireDateInput = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(hireDateInput))
            employee.HireDate = DateTime.Parse(hireDateInput);

        Console.Write("Is Active (true/false, leave blank to keep current): ");
        string isActiveInput = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(isActiveInput))
            employee.IsActive = bool.Parse(isActiveInput);

        Console.Write("Enter Email (leave blank to keep current): ");
        string email = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(email))
            employee.Email = email;

        Console.WriteLine("Employee updated successfully!");
    }
    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        employees.Remove(employee);
        Console.WriteLine("Employee deleted successfully!");
    }
}