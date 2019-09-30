using System;

namespace L3_Recursive_Drawing
{
    class Program
    {
        static void Print(int num)
        {
            if (num == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', num));

            Print(num - 1);

            Console.WriteLine(new string('#', num));
        }

        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            Print(number);
        }
    }
}
