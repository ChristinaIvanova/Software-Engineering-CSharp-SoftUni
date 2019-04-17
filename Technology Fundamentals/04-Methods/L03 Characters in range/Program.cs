using System;

namespace L03_Characters_in_range
{
    class Program
    {
        static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());

            char secondChar = char.Parse(Console.ReadLine());

            string range = CharactersInRange(firstChar, secondChar);

            Console.WriteLine(range);
        }

        private static string CharactersInRange(char a, char b)
        {
            char bigger = (char)Math.Max(a, b);

            char smaller = (char)Math.Min(a, b);

            string charactersInRange = string.Empty;

            for (char i = (char)(smaller+1); i <bigger; i++)
            {
                charactersInRange += i + " ";
            }
            return charactersInRange;
        }
    }
}
