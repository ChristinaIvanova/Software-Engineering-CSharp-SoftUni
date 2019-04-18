using System;

namespace E04_Password_Validator_
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();

            bool stringLenght = PasswordLenght(password);
            bool lettersAndDigits = ContentValidator(password);
            bool countDigits = NumberOfDigitsValidator(password);

            if (!stringLenght)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!lettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!countDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (stringLenght && lettersAndDigits && countDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool NumberOfDigitsValidator(string password)
        {
            int countDigits = 0;

            foreach (char symbol in password)
            {
                if (symbol >= 48 && symbol <= 57)
                {
                    countDigits++;
                }
            }

            if (countDigits < 2)
            {

                return false;
            }
            else
            {
                return true;
            }

        }

        private static bool PasswordLenght(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ContentValidator(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }

            }
            return true;

        }
    }
}
