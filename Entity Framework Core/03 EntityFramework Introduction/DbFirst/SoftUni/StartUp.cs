using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Remotion.Linq.Clauses;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = GetAddressesByTown(context);

            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = string.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    Name = e.FirstName,
                    Salary = e.Salary
                })
                .Where(e => e.Salary > 50000)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    Name = string.Join(" ", e.FirstName, e.LastName),
                    Department = e.Department.Name,
                    Salary = e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} from {employee.Department} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            employeeNakov.Address = address;

            context.SaveChanges();

            var employeesAddress = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    AddtessText = e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var employee in employeesAddress)
            {
                sb.AppendLine(employee.AddtessText);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))

                .Select(e => new
                {
                    Name = string.Join(" ", e.FirstName, e.LastName),
                    Manager = string.Join(" ", e.Manager.FirstName, e.Manager.LastName),
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project)
                        .ToList()
                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} - Manager: {employee.Manager}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = project.EndDate == null ?
                        "not finished" :
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                    //sb.AppendLine(
                    //  $"--{project.Name} - {project.StartDate:MM/dd/yyyy} {project.StartDate:h:mm:ss tt} - {(project.EndDate == null ? "not finished" : $"{project.EndDate:MM/dd/yyyy} {project.EndDate:h:mm:ss tt}")}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
