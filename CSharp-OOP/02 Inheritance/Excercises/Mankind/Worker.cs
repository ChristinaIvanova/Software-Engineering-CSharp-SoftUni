using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private const string ErrorMsg = "Expected value mismatch! Argument: {0}";

        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string secondName, double weekSalary, double workHoursPerDay)
            : base(firstName, secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException(string.Format(ErrorMsg, nameof(this.weekSalary)));
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException(string.Format(ErrorMsg, nameof(this.workHoursPerDay)));
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            return this.WeekSalary / (this.workHoursPerDay * 5);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
