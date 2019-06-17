namespace E02_Generic_Box_of_Integer
{
    using System;

    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var conten = int.Parse(Console.ReadLine());

                var boxOfInteger = new Box<int>(conten);
                Console.WriteLine(boxOfInteger);
            }
        }
    }
}
