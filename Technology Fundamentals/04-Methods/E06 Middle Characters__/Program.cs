using System;

namespace Е06_Middle_Characters
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Console.WriteLine(GetMiddleCharacters(text));
        }

        private static string GetMiddleCharacters(string text)
        {

            if (text.Length % 2 == 0)
            {
                return $"{text[text.Length / 2 - 1]}{text[text.Length / 2]}";
            }
            else
            {
                return $"{text[text.Length / 2]}";
            }
        }
    }
}
