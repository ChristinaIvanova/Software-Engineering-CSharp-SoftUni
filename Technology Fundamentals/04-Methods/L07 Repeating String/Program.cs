using System;

namespace L07_Repeating_String
{
    class Program
    {
        static void Main()
        {
            string receivedString = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result=RepeatString(receivedString,count);
            Console.WriteLine(result);
        }

        private static string RepeatString(string str,int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += str;
            }

            return result;
        }
    }
}
