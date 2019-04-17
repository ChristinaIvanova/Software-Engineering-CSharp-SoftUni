using System;
using System.Linq;
namespace E02_Vowel_count
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();

            int count = CountVowelsInText(text);

            Console.WriteLine(count);
        }

        private static int CountVowelsInText(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'A' || text[i] == 'e' || text[i] == 'E' || +
                    text[i] == 'i' || text[i] == 'I' || text[i] == 'o' || text[i] == 'O' ||
                    text[i] == 'u' || text[i] == 'U')
                {
                    counter++;
                }
            } 
            return counter;
        }
    }
}
