using System;

namespace E04_Password_Validator
{
    class Program
    {
        static void Main()
        {

            //bool numberCharacters = //PasswordLenght(password);
            //bool lettersAndDigits = //LetersAndDigitsValidator(password);
            //bool numberOfDigits = //DigitsValidator();

            Console.WriteLine("Password is valid");
            string password = Console.ReadLine();
            int countCharacters = 0;
            int countDigits = 0;

            foreach (char symbol in password)
            {
                if ((symbol >= 65 && symbol <= 90) || (symbol >= 97 && symbol <= 122))
                {
                    countCharacters++;
                }
                else if (symbol >= 48 && symbol <= 57)
                {
                    countDigits++;
                }
                else
                {
                    Console.WriteLine("Password must consist only of letters and digits"););
                    return false;
                }
            }
            if (countDigits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
            else
            {
                return true;
            }
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
        }
    }
}
