using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private const int MinFirstNameLenght = 4;
        private const int MinSecondNameLenght = 3;

        private string firstName;
        private string secondName;
        
        public Human(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                ValidateFirstLetter(value, nameof(this.firstName));

                ValidateLenght(value, MinFirstNameLenght, nameof(this.firstName));

                this.firstName = value;
            }
        }

        public string SecondName
        {
            get => this.secondName;
            private set
            {
                ValidateFirstLetter(value, nameof(this.secondName));

                ValidateLenght(value, MinSecondNameLenght, nameof(this.secondName));

                this.secondName = value;
            }
        }

        private void ValidateFirstLetter(string value, string parameterName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {parameterName}");
            }
        }

        private void ValidateLenght(string value, int length, string parameter)
        {
            if (value.Length < length)
            {
                throw new ArgumentException($"Expected length at least {length} symbols! Argument: {parameter}");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.SecondName}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
