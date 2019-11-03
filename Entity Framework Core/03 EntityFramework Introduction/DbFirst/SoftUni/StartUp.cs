using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(result);
        }

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

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb=new StringBuilder();

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
    }
}
