using System;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumer;

        public Student(string firstName, string secondName, string facultyNumer)
                    : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumer;
        }

        public string FacultyNumber
        {
            get => this.facultyNumer;
            private set
            {
                if (value.Length < 5 || value.Length > 10 ||
                   value.All(c => char.IsLetterOrDigit(c)) == false)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumer = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}
