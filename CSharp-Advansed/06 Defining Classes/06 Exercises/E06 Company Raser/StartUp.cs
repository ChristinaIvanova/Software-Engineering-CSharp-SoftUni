namespace E06_Company_Roster
{
    using E06_Company_Raser;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < employeesCount; i++)
            {
                var employeeArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = employeeArgs[0];
                var salary = double.Parse(employeeArgs[1]);
                var position = employeeArgs[2];
                var department = employeeArgs[3];
                var email = "n/a";
                var age = -1;

                if (employeeArgs.Length == 6)
                {
                    email = employeeArgs[4];
                    age = int.Parse(employeeArgs[5]);
                }
                else if (employeeArgs.Length == 5)
                {
                    if (employeeArgs[4].Contains("@"))
                    {
                        email = employeeArgs[4];
                    }
                    else
                    {
                        age = int.Parse(employeeArgs[4]);
                    }
                }

                var employee = new Employee(name, salary, position, department, email, age);
                employees.Add(employee);
            }

            var bestPaidDept = employees
                .GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
                .OrderByDescending(o => o.AvgSalary)
                .First()
                .Department;

            Console.WriteLine($"Highest Average Salary: {bestPaidDept}");

            employees
                .Where(d => d.Department == bestPaidDept)
                .OrderByDescending(e => e.Salary)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
