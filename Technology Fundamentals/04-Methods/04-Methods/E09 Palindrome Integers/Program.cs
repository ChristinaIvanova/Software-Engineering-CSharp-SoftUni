using System;

namespace E09_Palindrome_Integers
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();

            PalindromChecker(command);
        }

        private static string PalindromChecker(string command)
        {
            string reversed = string.Empty;

            while (command != "END")
            {
                for (int i = command.Length - 1; i >= 0; i--)
                {
                    char character = command[i];
                    reversed += character;
                }

                bool isPalindrome = (command == reversed);

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                reversed = string.Empty;
                command = Console.ReadLine();

            }

            return command;
        }
    }
}
