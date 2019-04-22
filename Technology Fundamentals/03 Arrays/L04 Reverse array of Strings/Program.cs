using System;
using System.Linq;
namespace _0004L_Reverse_array_of_Strings
{
    class Program
    {
        static void Main()
        {
            string[] text = Console.ReadLine().Split();
            for (int i = 0; i < text.Length / 2; i++)
            {
                string firstText = text[i];
                int indexReversed = text.Length - i - 1;
                text[i] = text[indexReversed];
                text[indexReversed] = firstText;
            }
            Console.WriteLine(string.Join(" ", text));
            //for (int i = text.Length - 1; i >= 0; i--)
            //{
            //    Console.WriteLine(text[i]);
            //}
        }
    }
}
